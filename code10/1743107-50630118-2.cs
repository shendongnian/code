	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<ActionResult> SubmitCallDetailsAsync(CallDetailViewModel callDetailViewModel)
	{
		using (var unitOfWork = new UnitOfWork(ApplicationDbContext))
		{
			// Call Details
			var callDetailServices = new CallDetailServices();
			await callDetailServices.AddOrUpdateCallDetailFromCallDetailViewModelAsync(callDetailViewModel, ModelState, unitOfWork);
			// Callers
			var callerServices = new CallerServices();
			await callerServices.AddOrUpdateCallersFromCallDetailsViewModelAsync(callDetailViewModel, ModelState, unitOfWork);
			// Children
			var childServices = new ChildServices();
			await childServices.AddOrUpdateChildrenFromCallDetailsViewModelAsync(callDetailViewModel, ModelState, unitOfWork);
			// Call Note
			var callNoteServices = new CallNoteServices();
			await callNoteServices.AddOrUpdateCallNoteFromCallDetailsViewModelAsync(callDetailViewModel, ModelState, unitOfWork);
			
			// Check the model state
			if (!UtilityServices.CheckModelState(ModelState))
			{
				// Setup all drop downs
				callDetailViewModel.DirectionChoices =
					await unitOfWork.DirectionChoiceRepo.GetAllAsSelectListItemsAsNoTrackingAsync();
				foreach (var callerViewModel in callDetailViewModel.CallerViewModels)
				{
					await callerServices.SetupSelectListItemsAsync(callerViewModel, unitOfWork);
				}
				foreach (var childViewModel in callDetailViewModel.ChildViewModels)
				{
					childViewModel.SexChoices = await unitOfWork.SexChoiceRepo.GetAllAsSelectListItemsAsNoTrackingAsync();
				}
				// Return the ViewModel with Validation messages
				if (Request.IsAjaxRequest()) return PartialView("_PartialCallDetail", callDetailViewModel);
				return View("Contact", callDetailViewModel);
			}
			await unitOfWork.CompleteAsync();
		}
		
		return Json(new { redirectUrl = Url.Action("Index", "Home", null) });
	}
