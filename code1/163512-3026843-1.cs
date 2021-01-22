    [DllImport("Test.dll")]
    [return : MarshalAs(UnmanagedType.I4)]
    private static extern int externalTestString(
        [MarshalAs(UnmanagedType. // The string type the C uses ansi/unicode/...) ] String st
        );
    public int TestString(String st // or string builder here)
    {
         // Perform input/output checks here + exception handling
    }
