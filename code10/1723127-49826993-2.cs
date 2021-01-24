    try
    {
        using (var unitOfWork = _unitOfWorkManager.Begin(TransactionScopeOption.RequiresNew))
        {
            _personRepository.Insert(person);
            // Save changes
            _unitOfWorkManager.Current.SaveChanges();
            var result = externalWebService.IncrementPeopleCount();
            if (result != 200)
            {
                // Rollback
                throw new MyExternalWebServiceException("Unable to increment people count!");
            }
            // Commit
            unitOfWork.Complete();
        }
    }
    catch (MyExternalWebServiceException)
    {
        // Transaction rolled back, propagate exception?
        throw;
    }
