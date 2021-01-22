    public static class Extensions
    {
        public static BindingList<T> ToBindingList<T>(this IList<T> list)
        {
            return new BindingList<T>(list);
        }
    }
