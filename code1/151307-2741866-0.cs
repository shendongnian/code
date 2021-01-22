    public static string Tester(string input)
    {
        string pattern = "\\W";
        string data = Regex.Replace(input.ToLower(), pattern, String.Empty);
            
        if (data == StringHelper.ReverseString(data))
        {
            Console.Write(input); Console.Write(" is a Palindrome.");
        }
        else
        {
            Console.Write(input); Console.Write(" isn't a Palindrome.");
        }
        return input;
    }
