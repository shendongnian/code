    public static class StringEscape
    {
      static char[] toEscape = "\0\x1\x2\x3\x4\x5\x6\a\b\t\n\v\f\r\xe\xf\x10\x11\x12\x13\x14\x15\x16\x17\x18\x19\x1a\x1b\x1c\x1d\x1e\x1f\"\\".ToCharArray();
      static string[] literals = @"\0,\x0001,\x0002,\x0003,\x0004,\x0005,\x0006,\a,\b,\t,\n,\v,\f,\r,\x000e,\x000f,\x0010,\x0011,\x0012,\x0013,\x0014,\x0015,\x0016,\x0017,\x0018,\x0019,\x001a,\x001b,\x001c,\x001d,\x001e,\x001f".Split(new char[] { ',' });
    
      public static string Escape(this string input)
      {
        int i = input.IndexOfAny(toEscape);
        if (i < 0) return input;
    
        var sb = new System.Text.StringBuilder(input.Length + 5);
        int j = 0;
        do
        {
          sb.Append(input, j, i - j);
          var c = input[i];
          if (c < 0x20) sb.Append(literals[c]); else sb.Append(@"\").Append(c);
        } while ((i = input.IndexOfAny(toEscape, j = ++i)) > 0);
    
        return sb.Append(input, j, input.Length - j).ToString();
      }
    }
