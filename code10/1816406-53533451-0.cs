    public class User 
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public override bool Equals(object obj)
        {
            var user = obj as User;
            return user != null &&
                   Name == user.Name &&
                   Password == user.Password;
        }
        public override int GetHashCode()
        {
            var hashCode = 1290039854;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            return hashCode;
        }
    }
