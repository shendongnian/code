    class UserEqualityComparer : IEqualityComparer<User>
    {
        bool IEqualityComparer.Equals(User lhs, User rhs)
        {
            return lhs.ID == rhs.ID;
        }
        int IEqualityComparer.GetHashCode(User user)
        {
            return user.ID;  // assumes all IDs are unique.
        }
    }
