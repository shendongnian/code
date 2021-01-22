    public int GetLeadingNumber(string input)
    {
        char[] chars = input.ToCharArray();
        int lastValid = -1;
    
        for(int i = 0; i < chars.Length; i++)
        {
            if(Char.IsDigit(chars[i]))
            {
                lastValid = i;
            }
            else
            {
                break;
            }
        }
    
        if(lastValid >= 0)
        {
            return int.Parse(new string(chars, 0, lastValid + 1));
        }
        else
        {
            return -1;
        }
    }
