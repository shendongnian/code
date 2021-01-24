            public void SwitchUsernames(Guid personIdOld, Guid personIdNew)
            {
                // Get accounts
                var personOld = Accounts.Find(personIdOld);
                var personNew = Accounts.Find(personIdNew);
    
                // switch usernames
                string usernamePersonOld = personOld.UserName;
                string usernamePersonNew = personNew.UserName;
    
                using (var tran = _context.Database.BeginTransaction())
                {
                    var temp = "TempName" + Guid.NewGuid().ToString();
                    personOld.UserName = temp;
                    _context.SaveChanges();
    
                    personNew.UserName = usernamePersonOld;
                    _context.SaveChanges();
    
                    personOld.UserName = usernamePersonNew;
                    _context.SaveChanges();
    
                    tran.Commit();
                }
            }
