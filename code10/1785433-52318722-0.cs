    public static string Get(string[] array)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < array.Length - 1; i++)
        {
            var link = array[i];
            var words = link.Split('-', '=');
            sb.Append(words.First());
            // Link will contain either of the separators
            if (link.Contains('-'))
            {
                sb.Append('-');
            }
            if (link.Contains('='))
            {
                sb.Append('=');
            }
        }
        sb.Append(array.Last());
        return sb.ToString();
    }
