    [AcceptVerbs(HttpVerbs.Post)] //This is KEY <-----
            public ActionResult Index(string userName)
            {
                //simple example, take input and pass back out
                TempData["Message"] = "Hello, " + userName;
                return View("Index",TempData);
            }
