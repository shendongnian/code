    public void Conversion(object objA, object objB)
    {
        // Fail out early if the objects provided are not the correct type, or are null
        if (!(objA is string str) || !(objB is int num)) { return; }
        // Now, you have `str` and `num` that are safely cast, non-null variables
        // all while maintaining the same scope as your Conversion method
        Console.WriteLine("str.Length is " + str.Length);
        Console.WriteLine("num is " + num);
    }
