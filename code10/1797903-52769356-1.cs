    var query3 = (	join u in db1.Users
				  from c in db1.Contacts 
				    on new { Record = c.RecordID, Type = c.RecordType } equals new { Record = u.Id, Type = "USR"} into b
				  from cont in b.DefaultIfEmpty(new Models.Contacts())
				  where u.Lastname.Contains(name)
				  && u.Active == 1
				  select new
				  {
					  u.Id,
					  u.FirstName,
					  u.Lastname,
					  u.FullName,
					  cont.Contact                          
				  }).ToList();
