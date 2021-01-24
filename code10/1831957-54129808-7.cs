    private static string SplitCut( string input, int length)
    {
        var words = input.Split(" ");
        StringBuilder builder = new StringBuilder();
        foreach (var word in words)
        {
            if ( builder.Length + word.Length <= length)
            {
                builder.Append(word);
            }
            else
            {
                //can't add more
                break;
            }
        }
        if (builder.Length == 0)
            return "Can't cut off without breaking word";
        return builder.ToString();
    }
