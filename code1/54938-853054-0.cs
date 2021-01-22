    public static T Parse<T>(string value)
    {
        // return a value of type T
    }
    public static void Parse<T>(string value, out T eValue)
    {
        // do something and set the out parameter
    }
    // now can be called via either
    SomeEnum blah = Enums.Parse<SomeEnum>("blah");
    // OR
    SomeEnum blah;
    Enums.Parse("blah", out blah);
