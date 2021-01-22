    public static string ToAlphaNumeric(string input)
    {
        int newLength = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsLetterOrDigit(input[i]))
            {
                newLength++;
            }
        }
        char[] newCharArr = new char[newLength];
        for (int i = 0, j = 0; i < input.Length; i++)
        {
            if (char.IsLetterOrDigit(input[i]))
            {
                newCharArr[j] = input[i];
                j++;
            }
        }
        return new string(newCharArr);
    }
