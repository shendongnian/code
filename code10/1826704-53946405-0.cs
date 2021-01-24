    public class DataSeeder
    {
        public static void SeedRandomPassword(YourDbContext context)
        {
                //// your custom logic to generate random password 
                //// set it to right user
    
                context.Users.Add();  // Or Update depending on what you need
                context.SaveChanges();
            }
        }
    }
