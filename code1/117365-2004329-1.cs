    var baseQuery = 
            plannerDb.Calendars.Where(
            row => row.UserId == userId && 
                   row.BindingClassName == bindingClassName);
    
    var first = baseQuery.OrderBy(row => row.StartDate).First();
    var last = baseQuery.OrderByDescending(row => row.StartDate).Select(
               row => row.EndDate).First();
    return new Calendar()
        {
            AppointmentId = first.AppointmentId,
            AllDay = first.AllDay,
            BindingClassName = first.BindingClassName,
            Description = first.Description,
            EndDate = last,
            StartDate = first.StartDate,
            Title = first.Title,
            Where = first.Where,
            UserId = first.UserId
        });
