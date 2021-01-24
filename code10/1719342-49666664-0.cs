     using System.Globalization;
     ... 
     public static double ReadDouble(string title = null) {
       if (!string.IsNullOrWhiteSpace(title)) 
         Console.WriteLine(title);
       while (true) {
         if (double.TryParse(Console.ReadLine(), 
                             NumberStyles.Any,             // accept any style
                             CultureInfo.InvariantCulture, // invariant culture with . decimal
                             out var result))              // out var - C# 7.0 syntax
           return result;
         Console.WriteLine("Sorry, incorrect syntax, repeat the input");
       }
     }
