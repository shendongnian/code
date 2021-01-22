    [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
            {
               try
               {
                  string selectedvalue = collection["Template"];
            
                  return RedirectToAction("Edit");
               }
               catch
               {
                  return View(new PageViewModel());
               }
            }
