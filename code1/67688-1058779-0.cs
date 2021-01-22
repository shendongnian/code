        public Dictionary<string, string> ValidateEntry(Object obj)
        {
            var errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(obj.Owner))
            {
                errors.Add("Owner", "You must select Owned By.");
            }
            //... whatever else
            return errors;
        }
         [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Object cap)
        {
           var errors = ValidateEntry(cap);
            if (errors.Count > 0)
            {
                foreach (var err in errors)
                {
                    ModelState.AddModelError(err.Key, err.Value);
                }
            }
            if (ModelState.IsValid)
            {
               //... do if valid
            }
            return View(ViewModel);
        }
