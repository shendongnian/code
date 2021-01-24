    opps.Add(new Opportunity()
    {
        DelegateList = orderLine.DelegatesList
            .Select(delegates => newDelegates
        {            
                FirstName = delegates.FirstName,
                LastName = delegates.LastName,
                Email = delegates.Email
        }).ToList(),
        
        CourseId = ...
