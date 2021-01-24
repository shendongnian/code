    var results = Offer.Select(o => new OfferResponseModel
        {
            Offer = new OfferRequestModel
            { 
                User = o.User.Adapt<UserResponseModel>(),
                Responsible = o.Responsible.Adapt<EmployeeResponseModel>()
            },
            CreatedDate = o.CreatedDate,
            ModifiedBy = Guid.Parse(o.UpdatedBy),
            Active = o.Status
        }).ToList();
