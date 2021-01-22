    public static bool IsNumeric(string value)
    {
        bool isNumber = true;
    
        bool afterDecimal = false;
        for (int i=0; i<value.Length; i++)
        {
            char c = value[i];
            if (c == '-' && i == 0) continue;
    
            if (Char.IsDigit(c))
            {
                continue;
            }
    
            if (c == '.' && !afterDecimal)
            {
                afterDecimal = true;
                continue;
            }
    
            isNumber = false;
            break;
        }
    
        return isNumber;
    }
