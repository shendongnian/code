    public static int AddIntegers(params int[] numbers) =>
        AddIntegers((IEnumerable<int>) numbers);
    public static int AddIntegers(IEnumerable<int> numbers)
    {
        ...
    }
