    public static class PersonExtensions
    {
        public static string GetName(this Person p)
        {
            foo();
            return p.Name;
        }
    }
