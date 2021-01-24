    static bool IsLegalUnicode(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            var uc = char.GetUnicodeCategory(str, i);
                
            if (uc == UnicodeCategory.Surrogate)
            {
                // Unpaired surrogate, like  ""[0] + "A" or  ""[1] + "A"
                return false;
            }
            else if (uc == UnicodeCategory.OtherNotAssigned)
            {
                // \uF000 or \U00030000
                return false;
            }
        }
        return true;
    }
