    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is User another)
            {
                return Name == another.Name && Password == another.Password;
            }
            return base.Equals(obj);
        }
        public static bool operator ==(User left, User right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(User left, User right)
        {
            return !left.Equals(right);
        }
    }
