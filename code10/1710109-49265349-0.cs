     using System.Data.Entity;
     using System.Linq;
     public class NameDbContextSeedData : 
     DropCreateDatabaseIfModelChanges<NameDbContext>
     {
        protected override void Seed(NameDbContext context)
        {
            var user = context.Users.Where(c => c.UserName ==
            "someone@someplace.com").Single();
 
            user.UserName = "someone@someplace.com";
            user.Email = "someone@someplace.com";
            user.EmailConfirmed = true;
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
            context.Commit();
        }
    }
