        public static bool ValidateLogin(string email, string password)
        {
            return users.Any(x => x.Email.Equals(email) && x.Password.Equals(password)) ? true : false;
        }
        private static List<User> users = new List<User>()
        {
            new User(){Email = "Tera@gmail.com", Password = "p@ssword"},
            new User(){Email = "Mega@email.com", Password = "password"},
        };
