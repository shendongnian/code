    public static class Extensions
    {
        // extends IEnumerable to allow conversion to a custom type
        public static TCollection ToMyCustomCollection<TCollection, T>(this IEnumerable<T> ienum)
               where TCollection : IList<T>, new()
        {
            // create our new custom type to populate and return
            TCollection collection = new TCollection();
            // iterate over the enumeration
            foreach (var item in ienum)
            {
                // add to our collection
                collection.Add((T)item);
            }
            return collection;
        }
    }
