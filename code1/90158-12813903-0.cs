        using(DbContext dbContext = new DbContext())
        {
            UserData curData = dc.Users.Where(λ => (λ.Login == username) && λ.Active).SingleOrDefault(); // You need(!) to use SingleOrDefault or FirstOrDefault
            if(curData != null) 
            {
                curData.LastIP = 'xx.xx.xx.xx';
                curData.LastVisit = DateTime.Now;
                dbContext.SaveChanges();
            }
        }
