    try
    {
        using (var unitOfWork = _unitOfWorkManager.Begin(TransactionScopeOption.RequiresNew))
        {
            _personRepository.Insert(person);
            var result = externalWebService.IncrementPeopleCount();
            if (result != 200)
            {
                throw new MyExternalWebServiceException("Unable to increment people count!");
            }
            unitOfWork.Complete();
        }
    }
    catch (MyExternalWebServiceException)
    {
        // Transaction rolled back, propagate exception?
        throw;
    }
