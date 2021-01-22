        public static T SingleOrDefault<T> ( this IEnumerable<T> source, 
                                        Func<T, bool> action, T theDefault )
        {
            T item = source.SingleOrDefault<T>(action);
            
            if (item != null)
                return item;
            
            return theDefault;
        }
