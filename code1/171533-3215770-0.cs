    var business = from businesse in context.tblBusinesses 
                 where businesse.BusinessID == businessID 
                select (businesse.BusinessName ?? string.Empty)
                     + (businesse.ContactName  ?? string.Empty)
                     + (businesse.tblPhones.Select(p=>p.PhoneNumber) 
                                          .FirstOrDefault()  
                                         ?? string.Empty); 
