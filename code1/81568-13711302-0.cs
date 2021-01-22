     public class SomeVM
        {
            public Dictionary<string, string> Fields { get; set; }
        }
    
        public class HomeController : Controller
        {
            [HttpGet]
            public ViewResult Edit()
            {
                SomeVM vm = new SomeVM
                {
                 Fields = new Dictionary<string, string>() {
                        { "Name1", "Value1"},
                        { "Name2", "Value2"}
                    }
                };
    
                return View(vm);
    
            }
    
            [HttpPost]
            public ViewResult Edit(SomeVM vm) //Posted values in vm.Fields
            {
                return View();
            }
        }
