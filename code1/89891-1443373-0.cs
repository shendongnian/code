    class TestController : Controller
    {
        [AcceptVerbs (HttpVerbs.Get)]
        public ActionResult SomeAction (FormCollection form)
        {
            if (MyCustomValidation (form))
                SaveData ();
    
            RedirectToAction ("SomeAction");
        }
    }
