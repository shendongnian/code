    public struct Something
    {
        //...
    }
    public static Something GetSomethingSomehow()
    {
        Something? data = MaybeGetSomethingFrom(theDatabase);
        bool questionMarkMeansNullable = (data == null);
        return data ?? Something.DefaultValue;
    }
