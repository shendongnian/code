        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(string cb)
        {
            ViewData["Message"] = cb;
            return View();
        }
