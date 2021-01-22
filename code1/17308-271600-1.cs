    // Both of these types mean the same thing, the ? is just C# shorthand.
    private void Example(int? arg1, Nullable<int> arg2)
    {
        if (arg1.HasValue)
            DoSomething();
        arg1 = null; // Valid.
        arg1 = 123;  // Also valid.
        DoSomethingWithInt(arg1); // NOT valid!
        DoSomethingWithInt(arg1.Value); // Valid.
    }
