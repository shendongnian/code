    public static class Extensions
    {
        public static bool FindByName(this IEnumerable<Type> list, string str)
        {
            return list.Any(x => x.name == str);
        }
    }
