using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet =true)] /*[BindProperty] attribute’unu kullanarak data modellerimizi sayfaya bağlamak mümkün. Bu sayede HTML tarafında bu özelliği kullanarak data modelinize ulaşmanız ve verileri taşımanız mümkün. MVC ile çok bir farkı yok, benzer konsept.*/
        public string SearchTerm { get; set; }

        public ListModel( IConfiguration config,
                          IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }

        public void OnGet(string SearchTerm)
        {

            //Message = "Hello, World !";
            SearchTerm = SearchTerm;
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}