      class NullCoalesce
     {
    static int? GetNullableInt()
    {
        return null;
    }
    static string GetStringValue()
    {
        return null;
    }
    static void Main()
    {
        // ?? operator example.
        int? x = null;
        // y = x, unless x is null, in which case y = -1.
        int y = x ?? -1;
        // Assign i to return value of method, unless
        // return value is null, in which case assign
        // default value of int to i.
        int i = GetNullableInt() ?? default(int);
        string s = GetStringValue();
        // ?? also works with reference types. 
        // Display contents of s, unless s is null, 
        // in which case display "Unspecified".
        Console.WriteLine(s ?? "Unspecified");
    }
}
