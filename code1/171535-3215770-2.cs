    var business = from businesse in context.tblBusinesses 
                 where businesse.BusinessID == businessID 
                select businesse.BusinessName ?? 
                       businesse.ContactName  ?? 
                       businesse.tblPhones.Select(p=>p.PhoneNumber) 
                                          .FirstOrDefault()  
                                         ?? string.Empty; 
