    public static class BaseExtensions
    {
        public static string Foo<T>(this IEnumerable<Base<T>> items) where T : new()
        {
            var builder = new StringBuilder();
            foreach (var item in items)
            {
                builder.Append(item.Foo());
            }
            return builder.ToString();
        }
    }
