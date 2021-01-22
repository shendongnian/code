    constraint CHasPlusEquals
    {
        static CHasPlusEquals operator + (CHasPlusEquals a, CHasPlusEquals b);
    }
    T SumElements<T>(T initVal, T[] values) where T : CHasPlusEquals
    {
        foreach (var v in values)
        {
            initVal += v;
        }
    }
