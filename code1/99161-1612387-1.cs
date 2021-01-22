    public static class MyCacheFor<T>
    {
        static MyCacheFor()
        {
            // grab the data
            Value = ExtractExpensiveData(typeof(T));
        }
        public static readonly MyExpensiveToExtractData Value;
        private static MyExpensiveToExtractData ExtractExpensiveData(Type type)
        {
            // ...
        }
    }
