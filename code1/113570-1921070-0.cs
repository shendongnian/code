    static void Main(string[] args)
    {
        string input = "012345678901234567890";
        
        // Create a StringBuilder with enough space
        StringBuilder sb = new StringBuilder(input.Length + input.Length / 10 * 3 + 3);
        
        sb.Append('"');
        for (int n = 0; n < input.Length; n++)
        {
            // don't add if this is the first char
            if (n > 0 && n % 10 == 0)
            {
                sb.Append("\"\n\"");
            }
            sb.Append(input[n]);
        }
        sb.Append('"');
        Console.WriteLine(sb.ToString());
    }
