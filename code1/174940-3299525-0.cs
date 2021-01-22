    public class User
    {
        ...
        public static implicit operator User(string x)
        {
            return new User(x);
        }
    }
