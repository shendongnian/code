    class Lockout : IDisposable
    {
      DirectoryContext context;
      DirectoryEntry root;
      DomainPolicy policy;
     
      public Lockout(string domainName)
      {
        this.context = new DirectoryContext(
          DirectoryContextType.Domain,
          domainName
          );
     
        //get our current domain policy
        Domain domain = Domain.GetDomain(this.context);
        
        this.root = domain.GetDirectoryEntry();
        this.policy = new DomainPolicy(this.root);      
      }
     
      public void FindLockedAccounts()
      {
        //default for when accounts stay locked indefinitely
        string qry = "(lockoutTime>=1)";
     
        TimeSpan duration = this.policy.LockoutDuration;
     
        if (duration != TimeSpan.MaxValue)
        {
          DateTime lockoutThreshold =
            DateTime.Now.Subtract(duration);
     
          qry = String.Format(
            "(lockoutTime>={0})",
            lockoutThreshold.ToFileTime()
            );
        }
        
        DirectorySearcher ds = new DirectorySearcher(
          this.root,
          qry
          );
     
        using (SearchResultCollection src = ds.FindAll())
        {
          foreach (SearchResult sr in src)
          {
            long ticks =
              (long)sr.Properties["lockoutTime"][0];
     
            Console.WriteLine(
              "{0} locked out at {1}",
              sr.Properties["name"][0],
              DateTime.FromFileTime(ticks)
              );
          }
        }
      }
      
      public void Dispose()
      {
        if (this.root != null)
        {
          this.root.Dispose();
        }
      }
    }
