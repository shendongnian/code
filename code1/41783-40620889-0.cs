        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult contact(Models.ContactInformation con)
        {
          if (string.IsNullOrEmpty(con.SelectedAgencySelectorType))
          {
            ModelState.AddModelError("", "You did not select an agency type.");
          }
    
          con.modelstate = ModelState;
          TempData["contact"] = con;
          if (!ModelState.IsValid) return RedirectToAction("contactinformation", "reports");
            
            //do stuff
            return RedirectToAction("contactinformation", "reports");
        }
