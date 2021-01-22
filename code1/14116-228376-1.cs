    public static unsafe string Reverse(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }
        fixed (char* pText = text)
        {
            char* pStart = pText;
            char* pEnd = pText + text.Length - 1;
            for (int i = text.Length / 2; i >= 0; i--)
            {
                char temp = *pStart;
                *pStart++ = *pEnd;
                *pEnd-- = temp;
            }
            return text;
        }
    }
