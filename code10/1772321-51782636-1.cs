        public class MasterController : Controller
        {
            [HttpPost]
            public ActionResult AddCurrency(int? id)
            {
                //return View();
                return View("/Views/Master/AddCurrency/AddCurrency.cshtml");
            }
    
            [HttpGet]
            public ActionResult CurrencyDetails()
            {
                //return View();
                return View("/Views/Master/CurrencyDetails/CurrencyDetails.cshtml");
            }
    
            [HttpDelete]
            public ActionResult DeleteDetail(int? id)
            {
                //return View();
                return View("/Views/Master/DeleteDetail/DeleteDetail.cshtml");
            }
        }
