         public ActionResult Form()
         {
            /* Declare viewData etc. */
            if (TempData["form"] != null)
            {
               /* Cast TempData["form"] to 
               System.Collections.Specialized.NameValueCollection 
               and use it */
            }
            return View("Form", viewData);
         }
