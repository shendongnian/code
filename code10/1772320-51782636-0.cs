        public class MasterController : Controller
        {
            [HttpPost]
            public ActionResult AddCurrency(int? id)
            {
                return View();
            }
    
            [HttpGet]
            public ActionResult CurrencyDetails()
            {
                return View();
            }
    
            [HttpDelete]
            public ActionResult DeleteDetail(int? id)
            {
                return View();
            }
        }
