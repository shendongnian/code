    [HttpPost]
    public async Task<IActionResult> Delete(int id, RegionSearchViewModel searchViewModel)
    {
        try
        {
            var validationResult = await new RegionHandler(_regionService).CanDelete(id);
            if (validationResult == null)
            {
                await _regionService.DeleteById(id);
                TempData[Constants.Common.ModalMessage] = Constants.Message.RecordSuccessDelete;
                return RedirectToAction(nameof(List), searchViewModel);
            }
            ModelState.AddModelError(validationResult);
        }
        catch (Exception ex)
        {
            var exceptionMessage = await Helpers.GetErrors(ex, _emailService);
            ModelState.AddModelError(new ValidationResult(exceptionMessage));
        }
        ModelState.AddModelError(string.Empty, "Invalid delete attempt.");
        return RedirectToAction(nameof(List), searchViewModel);
    }
