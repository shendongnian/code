    public struct Something
    {
        //...
    }
    public static Something GetSomethingSomehow()
    {
        Something? data = MaybeGetSomething(theDatabase);
        bool questionMarkMeansNullable = (data == null);
        return data ?? Something.DefaultValue;
    }
