    public class User
    {
        public string Name;
        
        public override int GetHashCode() => Name?.GetHashCode() ?? 0;
        public override bool Equals(object other) => (other as User)?.Name == Name;
    }
