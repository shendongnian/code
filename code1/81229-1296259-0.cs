    public MyController
    {
        [AcceptVerbs (HttpVerbs.Get)]
        public ActionResult Index ()
        {
            return View ();
        }
    
        [AcceptVerbs (HttpVerbs.Post)]
        public ActionResult Index (ClientSearch data, int? page)
        {
            // Process form post
    
            return RedirectToAction ("Index");
        }
    }
