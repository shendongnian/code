            [HandleError]
            public ActionResult Create(string urlToShorten)
            {
                if (string.IsNullOrEmpty(urlToShorten)) 
                {
                    return RedirectToAction("Index");
                }
                // No need for an else here since you have a return on the if above.
                long result = ShortUrlFunctions.GetIdForUrl(urlToShorten);
                // I am assuming that the function above returns 0 if url is not found.            
                if (result == 0)
                {
                    result = ShortUrlFunctions.InsertUrl(urlToShorten);
                }
                ViewData["shortUrl"] = result;
                return View("Create");
            }
