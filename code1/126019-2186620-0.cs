    public static class MyExtensions
    {
        public static bool AddNonNull(this HashSet<object> yourSet, object yourNewEntry)
        {
            if (yourNewEntry == null)
            {
                return false;
            }
            yourSet.Add(yourNewEntry);
            return false;
        }
    }
