    interface INumericPolicy<T>
    {
        T Zero();
        T Add(T a, T b);
        // add more functions here, such as multiplication etc.
    }
    
    struct NumericPolicies:
        INumericPolicy<int>,
        INumericPolicy<long>
        // add more INumericPolicy<> for different numeric types.
    {
        int INumericPolicy<int>.Zero() { return 0; }
        long INumericPolicy<long>.Zero() { return 0; }
        int INumericPolicy<int>.Add(int a, int b) { return a + b; }
        long INumericPolicy<long>.Add(long a, long b) { return a + b; }
        // implement all functions from INumericPolicy<> interfaces.
        public static NumericPolicies Instance = new NumericPolicies();
    }
