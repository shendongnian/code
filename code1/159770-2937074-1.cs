    [AcceptVerbs(HttpVerbs.Post), Authorize]
        public ActionResult Edit(int id, FormCollection formValues)
        {
    
            var dinner=new DinnerFormViewModel(dinnerRepository.GetDinner(id));
    
            try
            {
                UpdateModel(dinner);
                var x = ViewData.GetModelStateErrors(); // <-- to catch other ModelState errors
    
                dinnerRepository.Save();
    
                return RedirectToAction("Details", new { id = dinner.Dinner.DinnerID });
            }
            catch
            {
    
                ModelState.AddRuleViolations(dinner.GetRuleViolations());
    
                return View(new DinnerFormViewModel(dinner)); 
            }
        }
