    public class ShopController : Controller {
        
        //eg MySite.com/UserShop
        //eg MySite.com/UserShop/index
        public ActionResult Index(string shopName) {
            return View();
        }
        
        //eg MySite.com/UserShop/contact
        public ActionResult Contact(string shopName) {
            return View();
        }
        
        //eg MySite.com/UserShop/about
        public ActionResult About(string shopName) {
            return View();
        }
        
        //...other actions
    }
    
