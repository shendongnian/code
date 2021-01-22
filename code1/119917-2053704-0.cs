    [Transaction(Order=1)]
    public class TestController
    {
        public ActionResult Index()
        {
            return View();
        }
    
        [NoTransaction(Order=0)]
        public ActionResult Test()
        {
            return View();
        }
    }
