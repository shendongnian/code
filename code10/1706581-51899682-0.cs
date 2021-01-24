    public abstract class CommonController: Controller
    {
        protected readonly ITestBL bl;
    
        protected Controller1(ITestBL bl)
        {
            this.bl= bl;
        }
    
        [HttpGet]
        public virtual ActionResult Method1(string data)
        {
                var res = ...
    
                return Json(res, JsonRequestBehavior.AllowGet);
        }
    
        [HttpGet]
        public virtual ActionResult Method2(string data, int data2)
        {
                var res = ...
    
                return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
