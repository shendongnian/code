    public static void Add(ApplicationType application, 
	                       string username, 
						   string pageRequested, 
						   int recursionCount = 0)
    {
        using (var db = new CommonDAL()) // EF context
        {
            var exists = db.ActiveUsers.Find(username);
    
            if (exists != null)
			{
                exists.propa = "someVal";
			}
			else
			{
			    
                var activeUser = new ActiveUser 
				{ 
				    ApplicationID = application.Value(), 
					Username = username, 
					PageRequested = pageRequested, 
					TimeRequested = DateTime.Now 
		        };
				
                db.ActiveUsers.Add(activeUser);
			}
			try
			{
                db.SaveChanges();
			}
			catch(<Primary Key Violation>)
			{
				if(recursionCount < x)
				{
					Add(application, username, pageRequested, recursionCount++)
				}
				else
				{
					throw;
				}
			}
        }
    }
