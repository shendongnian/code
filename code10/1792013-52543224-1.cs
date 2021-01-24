    public override Task<Pair> BLPopAsync(IEnumerable<string> keys, TimeSpan? timeout)
    {
        if (IsTransaction)
            Console.WriteLine("IsTransaction equals true");
        return null;
    }
