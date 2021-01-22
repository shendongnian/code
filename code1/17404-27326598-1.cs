    public string Sentencify(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return string.Empty;
        string final = string.Empty;
        for (int i = 0; i < value.Length; i++)
        {
            final += (Char.IsUpper(value[i]) && ((i == 0 || !Char.IsUpper(value[i - 1])) ||
                                                 (i != (value.Length - 1) && !Char.IsUpper(value[i + 1]))) ?
                      " " : "") + value[i];
        }
        return final;
    }
