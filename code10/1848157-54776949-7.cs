    class CustomComparer : IEqualityComparer<string>
    {
        public bool Equals(string first, string second)
        {
            return first?.EqualsCaseExceptFirst(second) ?? false;
        }
        public int GetHashCode(string obj)
        {
            return obj?.GetHashCode() ?? 0;
        }
    }
