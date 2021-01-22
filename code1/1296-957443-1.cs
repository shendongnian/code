    [Flags]
    public enum ConfigOptions
    {
        None    = 0,
        A       = 1 << 0,
        B       = 1 << 1,
        Both    = A | B
    }
    Console.WriteLine( ConfigOptions.A.ToString() );
    Console.WriteLine( ConfigOptions.Both.ToString() );
    // Will print:
    // A
    // A, B
