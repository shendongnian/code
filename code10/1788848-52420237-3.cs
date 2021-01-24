    // untested
    public static TestEnum AllNotContaining(this TestEnum value)
    {
        return ~ value & TestEnum.All;
    }
