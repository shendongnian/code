    using System;
    using System.Text;
    using System.Linq;
    
    public static class StringLiteralEncoding {
      private static readonly char[] HEX_DIGIT_LOWER = "0123456789abcdef".ToCharArray();
      private static readonly char[] LITERALENCODE_ESCAPE_CHARS;
    
      static StringLiteralEncoding() {
        // Per http://msdn.microsoft.com/en-us/library/h21280bw.aspx
        var escapes = new string[] { "\aa", "\bb", "\ff", "\nn", "\rr", "\tt", "\vv", "\"\"", "\\\\", "??", "\00" };
        LITERALENCODE_ESCAPE_CHARS = new char[escapes.Max(e => e[0]) + 1];
        foreach(var escape in escapes)
          LITERALENCODE_ESCAPE_CHARS[escape[0]] = escape[1];
      }
    
      /// <summary>
      /// Convert the string to the equivalent C# string literal, enclosing the string in double quotes and inserting
      /// escape sequences as necessary.
      /// </summary>
      /// <param name="s">The string to be converted to a C# string literal.</param>
      /// <returns><paramref name="s"/> represented as a C# string literal.</returns>
      public static string Encode(string s) {
        if(null == s) return "null";
    
        var sb = new StringBuilder(s.Length + 2).Append('"');
        for(var rp = 0; rp < s.Length; rp++) {
          var c = s[rp];
          if(c < LITERALENCODE_ESCAPE_CHARS.Length && '\0' != LITERALENCODE_ESCAPE_CHARS[c])
            sb.Append('\\').Append(LITERALENCODE_ESCAPE_CHARS[c]);
          else if('~' >= c && c >= ' ')
            sb.Append(c);
          else
            sb.Append(@"\x")
              .Append(HEX_DIGIT_LOWER[c >> 12 & 0x0F])
              .Append(HEX_DIGIT_LOWER[c >>  8 & 0x0F])
              .Append(HEX_DIGIT_LOWER[c >>  4 & 0x0F])
              .Append(HEX_DIGIT_LOWER[c       & 0x0F]);
        }
        
        return sb.Append('"').ToString();
      }
    }
