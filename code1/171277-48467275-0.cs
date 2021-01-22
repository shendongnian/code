    public static unsafe void ToAlphaNumeric(ref string input)
    {
        fixed (char* p = input)
        {
            int offset = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetterOrDigit(p[i]))
                {
                    p[offset] = input[i];
                    offset++;
                }
            }
            ((int*)p)[-1] = offset; // Changes the length of the string
            p[offset] = '\0';
        }
    }
