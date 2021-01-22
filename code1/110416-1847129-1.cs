    public static class CollectionTestClass
    {
        public static Boolean IsEnumerable<T>(this Object testedObject)
        {
            return (testedObject is IEnumerable<T>);
        }
    }
