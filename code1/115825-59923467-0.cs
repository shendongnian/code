       int schedule=0;
       char c;
       string rack=string.Empty;
       for (i=0; i<inputString.Length; i++)
       {
        c=inputString[i];
        if (Char.IsDigit(c))
        {
         schedule=(10*schedule)+(c-'0');
        }
        else
        {
         rack+=c.ToString();
        }
       }
