    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    
    class C {
      public static void Main() {
        byte[] data = {0, 100, 0, 255, 100, 0, 100, 0, 255};
        byte[] pattern = {0, 255};
        foreach (int i in FindAll(data, pattern)) {
          Console.WriteLine(i);
        }
      }
    
      public static IEnumerable<int> FindAll(
        byte[] haystack,
        byte[] needle
      ) {
        // bytes <-> latin-1 conversion is loseless
        Encoding latin1 = Encoding.GetEncoding("iso-8859-1");
        string sHaystack = latin1.GetString(haystack);
        string sNeedle = latin1.GetString(needle);
        for (Match m = Regex.Match(sHaystack, Regex.Escape(sNeedle));
             m.Success; m = m.NextMatch()) {
          yield return m.Index;
        }
      }
    }
