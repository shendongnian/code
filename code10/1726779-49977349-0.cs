    [Theory,
    InlineData("1", "Description 1", ...),
    InlineData("2", "Description 2", ...),
    InlineData("3", "Description 3", ...)]
    public void Can_get_correct_age_for_date(string sno, string description, ...)
    {
        // you can access the paramaters here
        Console.WriteLine(sno);
        Console.WriteLine(description);
        // Assert Logic
        Assert.Equal(...);
    }
