    public static bool TryParseHindiToInt32(string text, out int value)
    {
        const int codePointForZero = 2406;
        const int codePointForNine = codePointForZero + 9;
        
        int sign = +1;
    
        int index = 0;
        if (index < text.Length && text[index] == '-') // todo: hindi minus?
        {
            index++;
            sign = -1;
        }
        
        value = 0;
        while (index < text.Length)
        {
            char c = text[index];
            if (c < codePointForZero || c > codePointForNine)
            {
                value = 0;
                return false;
            }
    
            if ((uint)value > 214748364u)
            {
                value = 0;
                return false;
            }
                
            value *= 10;
            value += (c - codePointForZero);
            index++;
        }
        
        value *= sign;
        return true;
    }
