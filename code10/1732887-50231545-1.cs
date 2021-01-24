    opps.Add(new Opportunity()
    {
        DelegateList = orderLine.DelegatesList
            .Select(delegates => new Delegates
        {            
                FirstName = delegates.FirstName,
                LastName = delegates.LastName,
                Email = delegates.Email
        }).ToList(),
        
        CourseId = ...
