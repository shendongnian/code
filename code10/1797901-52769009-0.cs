    var query3 = (from c in db1.Contacts
                  from u in db1.Users.Where(x => c.RecordID == x.Id).DefaultIfEmpty() 
                  where (c.RecordType == "USR")
                      && u.Lastname.Contains(name) && (u.Active == 1)
                  select new
                  {
                      u.Id,
                      u.FirstName,
                      u.Lastname,
                      u.FullName,
                      u.Contact                          
                   }).ToList();
