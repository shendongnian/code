    public class UserEqualityComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y) => x?.Name == y?.Name;
        public int GetHashCode(User obj) => obj?.Name?.GetHashCode() ?? 0;
    }
