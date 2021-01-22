    public static class Extensions
    {
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> collection,
            int n)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            if (n < 0)
                throw new ArgumentOutOfRangeException(nameof(n), $"{nameof(n)} must be 0 or greater");
                
            LinkedList<T> temp = new LinkedList<T>();
    
            foreach (var value in collection)
            {
                temp.AddLast(value);
                if (temp.Count > n)
                    temp.RemoveFirst();
            }
            
            return temp;
        }
    }
