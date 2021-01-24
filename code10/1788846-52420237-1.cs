    // untested
    public static IEnumerable<Enum> AllNotContaining(this Enum value)
    {
        var notUsedBits = ~ value & TestEnum.All;
    }
