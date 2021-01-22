    [HideFromStackTrace] // apply this to all methods you want omitted in stack traces
    static void ThrowIfNull(object arg, string paramName)
    {
        if (arg == null) throw new ArgumentNullException(paramName);
    }
    static void Foo(object something)
    {
        ThrowIfNull(something, nameof(something));
        …
    }
    static void Main()
    {
        try
        {
            Foo(null);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.GetStackTraceWithoutHiddenMethods());
        }                  // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
    }                      // gets a stack trace string representation
                           // that excludes all marked methods
