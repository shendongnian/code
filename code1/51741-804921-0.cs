    public class User
    {
        // ... User class goes here
        public static readonly User NullUser = new User();
    }
    public User ValidateUser(string Username, string Password)
    {
        DataContext db = new DataContext();
        var user = db.Users FirstOrDefault(u.Username == Username);
        return user ?? User.NullUser;
    }
