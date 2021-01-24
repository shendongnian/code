    public static bool ShorthandCompare(string str1, string str2)
    {
        if (str1 == null)
        {
            throw new ArgumentNullException(nameof(str1));
        }
        if (str2 == null)
        {
            throw new ArgumentNullException(nameof(str2));
        }
        if (str1 == string.Empty)
        {
            return str2 == string.Empty;
        }
        if (object.ReferenceEquals(str1, str2))
        {
            return true;
        }
        var ee1 = StringInfo.GetTextElementEnumerator(str1);
        var ee2 = StringInfo.GetTextElementEnumerator(str2);
        bool eos1, eos2 = true;
        while ((eos1 = ee1.MoveNext()) && (eos2 = ee2.MoveNext()))
        {
            string ch1 = ee1.GetTextElement(), ch2 = ee2.GetTextElement();
            // The string.Compare does some nifty tricks with unicode
            // like string.Compare("ì", "i\u0300") == 0
            if (string.Compare(ch1, ch2) == 0)
            {
                continue;
            }
            UnicodeCategory uc1 = char.GetUnicodeCategory(ch1, 0);
            UnicodeCategory uc2 = char.GetUnicodeCategory(ch2, 0);
            if (uc1 == UnicodeCategory.UppercaseLetter)
            {
                while (uc2 != UnicodeCategory.UppercaseLetter && (eos2 = ee2.MoveNext()))
                {
                    ch2 = ee2.GetTextElement();
                    uc2 = char.GetUnicodeCategory(ch2, 0);
                }
                if (!eos2 || string.Compare(ch1, ch2) != 0)
                {
                    return false;
                }
                continue;
            }
            else if (uc2 == UnicodeCategory.UppercaseLetter)
            {
                while (uc1 != UnicodeCategory.UppercaseLetter && (eos1 = ee1.MoveNext()))
                {
                    ch1 = ee1.GetTextElement();
                    uc1 = char.GetUnicodeCategory(ch1, 0);
                }
                if (!eos1 || string.Compare(ch1, ch2) != 0)
                {
                    return false;
                }
                continue;
            }
            // We already know they are different!
            return false;
        }
        if (eos1)
        {
            while (ee1.MoveNext())
            {
                string ch1 = ee1.GetTextElement();
                UnicodeCategory uc1 = char.GetUnicodeCategory(ch1, 0);
                if (uc1 == UnicodeCategory.UppercaseLetter)
                {
                    return false;
                }
            }
        }
        else if (eos2)
        {
            while (ee2.MoveNext())
            {
                string ch2 = ee2.GetTextElement();
                UnicodeCategory uc2 = char.GetUnicodeCategory(ch2, 0);
                if (uc2 == UnicodeCategory.UppercaseLetter)
                {
                    return false;
                }
            }
        }
        return true;
    }
