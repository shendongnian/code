    var business = from businesse in context.tblBusinesses 
                   where businesse.BusinessID == businessID 
                   select new
                   {
                       businesse.BusinessName,
                       businesse.ContactName,
                       Phone = businesse.tblPhones.Select(p=>p.PhoneNumber)
                           .FirstOrDefault() ?? string.Empty
                   }.Single();
    return (business.BusinessName ?? string.Empty) +
        (business.ContactName ?? string.Empty) +
        (business.Phone ?? string.Empty);
