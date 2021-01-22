    static void Main(string[] args)
    {
        string reverseMe = "hello world";
        string reversed = ReverseString(reverseMe);
        Console.WriteLine(reversed);
    }
    private static string ReverseString(string reverseMe)
    {
        if (String.IsNullOrEmpty(reverseMe)) return String.Empty;
        char[] reverseMeArray = reverseMe.ToCharArray();
        Array.Reverse(reverseMeArray);
        string result = new string(reverseMeArray);
        return result;
    }
