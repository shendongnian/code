    using System;
    
    namespace ExtensionLibrary
    {
      public static class Extensions
      {
        public static string CustomExtension(this string text)
        {
          char[] chars = text.ToCharArray();
          Array.Reverse(chars);
          return new string(chars);
        }
      }
    }
