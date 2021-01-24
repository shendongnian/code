	[HttpPost]
	public async Task<ActionResult> Index(Customer formData) {
		if (!ModelState.IsValid) {
			return View();
		}
		var ok = await CreateTrial(formData);
		return ok 
		    ? RedirectToAction("Index", "TrialConfirmation")
			: View(formData);
		}
	}
	
	protected async Task<bool> CreateTrial(Customer formData) {
		var apiOneService = new ApiOneService(formData);
		if (apiOneService.ExistingUserCheck()) return false;
		var emailTask = mailService.SendMailAsync((formData));
		var apiTwoResult = serviceTwo.CreateTrial(formData);
        await emailTask;
		return true;
    }
	
	
