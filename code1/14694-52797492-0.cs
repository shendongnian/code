    using System;
    using System.Text.RegularExpressions;
    class MainClass {
      public static void Main (string[] args) {
        string str = "AAA\r\nBBB\r\n\r\n\r\nCCC\r\r\rDDD\n\n\nEEE";
    
        Console.WriteLine (str.Replace(System.Environment.NewLine, "-"));
        /* Result:
        AAA
        -BBB
        -
        -
        -CCC
    
    
        DDD---EEE
        */
        Console.WriteLine (Regex.Replace(str, @"\r\n?|\n", "-"));
        // Result:
        // AAA-BBB---CCC---DDD---EEE
    
        Console.WriteLine (Regex.Replace(str, @"[\r\n]+", "-"));
        // Result:
        // AAA-BBB-CCC-DDD-EEE
      }
    }
