    public void MyContext : DbContext
    {
       public new int SaveChanges() //not relevant if it is new, you can do it in another method.
       {
           foreach(var e in this.Entries)
           {
               if(e.State == EntityState.Added)
               {
                  //log here
               }
           }
           return base.SaveChanges();
       }
    }
