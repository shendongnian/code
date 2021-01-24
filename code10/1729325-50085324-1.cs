        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( MyViewModel form)
        {
            if (ModelState.IsValid)
            {
               // Rest of ur code
            }
         }
