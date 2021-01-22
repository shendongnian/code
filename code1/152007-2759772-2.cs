    public static void Foo<TUnboxed>(object test)
                         where TUnboxed : struct
    {
        try
        {
            TUnboxed unboxed = (TUnboxed)test;
        }
        catch (InvalidCastException ex)
        {
            // handle the exception or re-throw it...
            throw ex;
        }
        // do stuff with 'unboxed'
    }
    public void TestFunc()
    {
        // box an int
        object o = 100;
        // Now call foo, letting it unbox the int.
        // Note that the generic type can not be infered
        // but has to be explicitly given, and has to match the 
        // boxed type, or throws an `InvalidCastException`
        Foo<int>(o);
    }
