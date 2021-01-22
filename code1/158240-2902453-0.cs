    public static string Right(string input, int length)
    {
        if (length >= input.Length)
        {
            return input;
        }
        else
        {
            return input.Substring(input.Length - length);
        }
    }
