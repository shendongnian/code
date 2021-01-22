    public class FooController : Controller
    {
        private ActionResult FooView(string name, string extension = "cshtml") { 
            return View("~/Areas/Bar/Views/Foo/" + name + "." + extension); }
        }
        public ActionResult SomeAction(){
          return FooView("AreaSpecificViewName");
        }
        public ActionResult SomeOtherAction(){
          return FooView("AnotherAreaSpecificViewName", "aspx");
        }
    }
