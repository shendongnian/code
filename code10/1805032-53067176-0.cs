    class MyOldDbContext : DbContext
    {
         public IDbSet<Aentity> Aentities {get; set;}
         public IDbSet<Bentity> BEntities {get; set;} 
         public void SomeRandomMethod()
         {   // this method uses the IdBsets AEntities and BEntities:
             IDbSet<AEntity> x = this.AEntities;
             IDbSet<BEntity> y = this.BEntities;
             ... // do something with x and y
         }
    }
