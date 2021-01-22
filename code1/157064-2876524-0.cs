    private string ApplyCustomFormat(string input)
    {
        StringBuilder builder = new StringBuilder(input.Replace("-", ""));
        int index = 3;
        while (index < builder.Length)
        {
            builder.Insert(index, "-");
            index += 4;
        }
        return builder.ToString();
    }
