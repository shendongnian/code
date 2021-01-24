       // could be [Route("[controller]/[action]") or it could left off all together
       [Route("[controller]")]  
       public class ShoppingCartController : Controller
       {
          public ShoppingCartController(ShoppingCart shoppingCart)
          {
             _shoppingCart = shoppingCart;
          }
          // your default route...
          public IActionResult Index()
          {
            ...
           }
        [HttpGet("{id}")] //not entirely necessary either (more of a partially forced route)
         public RedirectToActionResult AddToShoppingCart(int id)
         {
            //since routes are exact missing something like {id} would cause
            //route generator to skip any calls to this without the {id} in place.
         }
      }
