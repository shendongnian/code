    public int Method(MyEnum myEnum)
    {
        if (!IsDefined(typeof(MyEnum), myEnum)
        {
            throw new ArgumentOutOfRangeException(...);
        }
        // Adjust as necessary, e.g. by adding 1 or whatever
        return (int) myEnum; 
    }
