    public static class ObjectExtensions
    {
        public static bool Is<T>(this object ToEvaluate) 
        {
            return ToEvaluate is T;
        }
    }
