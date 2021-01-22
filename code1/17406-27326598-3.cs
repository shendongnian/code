    public string Sentencify(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;
        string final = string.Empty;
        for (int i = 0; i < value.Length; i++)
        {
            if (i != 0 && Char.IsUpper(value[i]))
            {
                if (!Char.IsUpper(value[i - 1]))
                    final += " ";
                else if (i < (value.Length - 1))
                {
                    if (!Char.IsUpper(value[i + 1]) && !((value.Length >= i && value[i + 1] == 's') ||
                                                         (value.Length >= i + 1 && value[i + 1] == 'e' && value[i + 2] == 's')))
                        final += " ";
                }
            }
            final += value[i];
        }
        return final;
    }
