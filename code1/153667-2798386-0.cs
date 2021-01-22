	[AcceptVerbs(HttpVerbs.Post)]
	public ActionResult Edit(int id, FormCollection formValues) {
		Dinner dinner = dinnerRepository.GetDinner(id);
		try {
			UpdateModel(dinner);
			dinnerRepository.Save();
            // No Errors, return to detail view
			return RedirectToAction("Details", new { id=dinner.DinnerID });
		}
		catch {
			foreach (var issue in dinner.GetRuleViolations()) {
				ModelState.AddModelError(issue.PropertyName, issue.ErrorMessage);
			}
            // Errors, display form again.  Pass state information back to form.
			return View(dinner);
		}
	}
