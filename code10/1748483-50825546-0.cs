    if (offer == null)
        throw ServiceExceptions.OfferNotFound;
    
    var results = offer.Select(o => new OfferResponseModel 
    {
        Offer = new OfferRequestModel 
        {
            User = o.User.Adapt<UserResponseModel>(),
            Responsible = o.Responsible.Adapt<EmployeeResponseModel>(),
            ...
        }
    }).ToList();
