    unsafe public static string Convert(string input)
    {
       fixed (char* pInput = input)
       {
          char* p1, p2, len = pInput + input.Length;
          for (p1 = p2 = pInput + 1; p2 < len; p1++, p2++)
             *p1 = *(p2 - 1) == '"' && *p2 == '_' ? char.ToUpper(*++p2) : *p2;
          return input.Substring(0, (int)(p1 - pInput));
       }
    }
