    public async Task<IActionResult> Post([FromBody]PaymentViewModel model)
    {
        var result = false;
        // Storing of card must pass
        try
        {
            using (var uow = _unitOfWorkManager.Begin(TransactionScopeOption.RequiresNew))
            {
                // ...
                
                await CurrentUnitOfWork.SaveChangesAsync();
                await uow.CompleteAsync();
            }
        }
        catch (Exception ex)
        {
            // Catch business exception, but storing
        }
        return Json(new { result });
    }
