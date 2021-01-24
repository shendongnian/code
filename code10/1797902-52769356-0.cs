    var query3 = (	join u in db1.Users
    				from c in db1.Contacts on c.RecordID equals u.Id into b
    				  from cont in b.DefaultIfEmpty(new Models.Contacts())
    				  where cont.RecordType == "USR"
    				  && u.Lastname.Contains(name)
    				  && u.Active == 1
    				  select new
    				  {
    					  u.Id,
    					  u.FirstName,
    					  u.Lastname,
    					  u.FullName,
    					  cont.Contact                          
    				  }).ToList();
