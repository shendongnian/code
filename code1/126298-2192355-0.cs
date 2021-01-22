    public static List<DAL.EntityClasses.AccountsEntity> Accounts             
    {             
        get             
        {  
          List<DAL.EntityClasses.AccountsEntity> accounts = 
           HttpContext.Current.Cache["Account"] as List<DAL.EntityClasses.AccountsEntity> 
          if(accounts == null)
          {
            accounts = LoadAccounts();
            HttpContext.Current.Cache.Insert("Account", accounts, null, DateTime.Now.AddHours(4), System.Web.Caching.Cache.NoSlidingExpiration);          
          }  
          return accounts;
       }
    }
