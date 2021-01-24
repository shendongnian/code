    static class AuthEngine {
         private static List<User> users;
         public static bool Validate(string email, string password) 
         {
            var matchedUser = users.FirstOrDefault(x => x.Email == email && x.Password == password);
            return matchedUser != null;
         }   
    }
