    class MyNewDbContext : DbContext
    {
         public DbSet<Aentity> Aentities {get; set;}
         public DbSet<Bentity> BEntities {get; set;} 
         public void SomeRandomMethod()
         {   // this method uses the DbSets AEntities and BEntities, which implement IDbSet
             IDbSet<AEntity> x = this.AEntities;
             IDbSet<BEntity> y = this.BEntities;
             ... // do something with x and y
         }
    }
