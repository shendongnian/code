    public static string RemoveDecimalsFromString(string input)
    {
        decimal IndexOfDot = input.IndexOf(".");
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < IndexOfDot; i++)
        {
            sb.Append(input[i]);
        }
                
        return sb.ToString();
    }
