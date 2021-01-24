    class MyNewDbContext : DbContext
    {
         public DbSet<Teacher> Teachers {get; set;}
         public DbSet<Student> Students {get; set;} 
         public void SomeRandomMethod()
         {   // this method uses the IdBset of AEntities and BEntities:
             IDbSet<AEntity> x = this.AEntities;
             IDbSet<BEntity> y = this.BEntities;
             ... // do something with x and y
         }
         // for SomeRandomMethod we need properties AEntities and BEntities
         // use your new DbSets to mimic the old AEntities and BEntities
         private IDbSet<AEntity> AEntities => this.Teachers
              .Join(this.Students, ...)
              .Where(...)
              .Select(...);
          // similar for BEntities
    }
