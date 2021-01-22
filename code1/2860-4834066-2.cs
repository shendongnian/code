    interface INumericPolicy<T>
    {
        T Zero();
        T Add(T a, T b);
        ...
    }
    
    class All: INumericPolicy<int>, INumericPolicy<long>, ...
    {
        ...
        public static All P = new All();
    }
