    public static class StringEscape
    {
      static char[] toEscape = "\0\x1\x2\x3\x4\x5\x6\a\b\t\n\v\f\r\xe\xf\x10\x11\x12\x13\x14\x15\x16\x17\x18\x19\x1a\x1b\x1c\x1d\x1e\x1f\"\\".ToCharArray();
      static string[] literals = @"0\x1\x2\x3\x4\x5\x6\a\b\t\n\v\f\r\xe\xf\x10\x11\x12\x13\x14\x15\x16\x17\x18\x19\x1a\x1b\x1c\x1d\x1e\x1f".Split(new char[] { '\\' });
    
      public static string ToLiteral(this string input)
      {
        int i = input.IndexOfAny(toEscape);
        if (i < 0) return input;
    
        var sb = new System.Text.StringBuilder("\"", input.Length + 5);
        int j = 0;
        do
        {
          sb.Append(input, j, i - j).Append(@"\");
          var c = input[i];
          if (c < 0x20) sb.Append(literals[c]); else sb.Append(c);
        } while ((i = input.IndexOfAny(toEscape, j = ++i)) > 0);
    
        return sb.Append(input, j, input.Length - j).Append("\"").ToString();
      }
    }
