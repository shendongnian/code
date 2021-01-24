    public class UserManager
    {
        private Entities db = new Entities();
        public bool IsValid(string username, string password)
        {
            // TODO: salt and hash.
            return db.USER.Any(u => u.USERNAME == username && u.PASSWORD == password);
        }
    }
