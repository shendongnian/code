    public static class CollectionInitializerExtensionMethods
    {
        public static void Add(this IList<JToken> list, IList<JToken> toAdd)
        {
             foreach (var a in toAdd)
             {
                 list.Add(a);
             }
        }
    }
