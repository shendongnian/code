    static string Unescape(string text)
    {
        StringBuilder builder = new StringBuilder(text.Length);
        bool escaping = false;
        foreach (char c in text)
        {
            if (escaping)
            {
               // We're not handling \uxxxx etc
               escaping = false;
               switch(c)
               {
                   case 'r': builder.Append('\r'); break;
                   case 'n': builder.Append('\n'); break;
                   case 't': builder.Append('\t'); break;
                   case '\': builder.Append('\\'); break;
                   default:
                       throw new ArgumentException("Unhandled escape: " + c);
               }
            }
            else
            {
               if (c == '\\')
               {
                   escaping = true;
               }
               else
               {
                   builder.Append(c);
               }
            }
        }
        if (escaping)
        {
            throw new ArgumentException("Unterminated escape sequence");
        }
        return builder.ToString();
    }
