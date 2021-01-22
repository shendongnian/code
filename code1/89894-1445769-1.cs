    class TestController : Controller
    {
        [AcceptVerbs (HttpVerbs.Post)]
        public ActionResult SomeAction (FormCollection form)
        {
            if (MyCustomValidation (form))
                SaveData ();
    
            RedirectToAction ("SomeAction");
        }
    }
