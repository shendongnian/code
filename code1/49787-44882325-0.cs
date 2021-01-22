    string SeparateCamelCase(string str)
    {
        for (int i = 1; i < str.Length; i++)
        {
            if (char.IsUpper(str[i]))
            {
                str = str.Insert(i, " ");
                i++;
            }
        }
        return str;
    }
