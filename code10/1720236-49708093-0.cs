    public static void Main(string[] args)
    {
        string str = "fafaffaa";
        char[] ArrChar = str.ToCharArray();
        Console.WriteLine("First Repeating char : {0}", MatChar(ArrChar));
    }
    public static char MatChar(char[] input)
    {
        HashSet<char> HasChar = new HashSet<char>();
        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            if (HasChar.Contains(c))
                return c;
            else
                HasChar.Add(c);
        }
        return '\0';
    }
