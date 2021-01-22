    public static class Extensions
    {
        public static IEnumerable<T> Last<T>(this IEnumerable<T> collection, int n)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");
            if (n < 0)
                throw new ArgumentOutOfRangeException("n", "n must be 0 or greater");
                
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
