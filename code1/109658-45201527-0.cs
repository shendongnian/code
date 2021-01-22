      public static bool IsIdentifier(string text)
      {
         if (string.IsNullOrEmpty(text))
            return false;
         if (!char.IsLetter(text[0]) && text[0] != '_')
            return false;
         for (int ix = 1; ix < text.Length; ++ix)
            if (!char.IsLetterOrDigit(text[ix]) && text[ix] != '_')
               return false;
         return true;
      }
