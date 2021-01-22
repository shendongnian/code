    public static class CollectionTestClass
    {
        public static Boolean IsEnumerable<T>(this Object testedObject)
        {
            if (testedObject is IEnumerable<T>)
            {
                return true;
            }
    
            return false;
        }
    }
