        [HttpGet]
        public ActionResult contactinformation()
        {
            //try cast to model
            var m = new Models.ContactInformation();
            if (TempData["contact"] is Models.ContactInformation) m = (Models.ContactInformation)TempData["contact"];
            
            //restore modelstate if needed
            if (!m.modelstate.IsValid)
            {
                foreach (ModelState item in m.modelstate.Values)
                {
                    foreach (ModelError err in item.Errors)
                    {
                        ModelState.AddModelError("", err.ErrorMessage.ToString());
                    }
                }
            }
            
            return View(m);
        }
