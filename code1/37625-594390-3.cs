    public void Test(BookCategory cat)
    {
        if (!Enum.IsDefined(typeof(BookCategory), cat))
        {
            throw new ArgumentOutOfRangeException("cat");
        }
    }
