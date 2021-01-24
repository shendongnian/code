    public static class Extensions
    {
        public static bool ContainsTypes(this List<BaseClass> list, params Type[] types)
        {
            return types.All(type => list.Any(x => x != null && type == x.GetType()));
        }
    }
