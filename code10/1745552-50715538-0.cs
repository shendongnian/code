    public static class JsonExtensions
    {
        public static TJToken RemoveEmptyArrayProperties<TJToken>(this TJToken root) where TJToken : JToken
        {
            var container = root as JContainer;
            if (container == null)
                return root;
            var query = container.DescendantsAndSelf()
                .OfType<JProperty>()
                .Where(p => p.Value is JArray && ((JArray)p.Value).Count == 0);
            foreach (var property in query.ToList())
            {
                property.Remove();
            }
            return root;
        }
    }
