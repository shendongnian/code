    public class UserRepository
    {
       YourDbContext dbContext = new YourDbContext();
    
       public bool IsUserAlreadyExistsByEmail(string email, int? id)
       {
          return dbContext.Users.Any(x => x.Email== Email && x.Id != Id);
       }
    }
