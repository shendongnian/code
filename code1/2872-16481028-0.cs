    public T DifficultCalculation<T>(T a, T b)
    {
        T result = a * b + a; // <== WILL NOT COMPILE!
        return result;
    }
    Console.WriteLine(DifficultCalculation(2, 3)); // Should result in 8.
