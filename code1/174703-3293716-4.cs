    class UserEqualityComparer : IEqualityComparer<User>
    {
        bool IEqualityComparer<User>.Equals(User lhs, User rhs)
        {
            return lhs.ID == rhs.ID;
        }
        int IEqualityComparer<User>.GetHashCode(User user)
        {
            return user.ID;  // assumes all IDs are unique.
        }
    }
