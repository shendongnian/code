    public static string ToAlphaNumeric(string input)
    {
        int j = 0;
        char[] newCharArr = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsLetterOrDigit(input[i]))
            {
                newCharArr[j] = input[i];
                j++;
            }
        }
        Array.Resize(ref newCharArr, j);
        return new string(newCharArr);
    }
