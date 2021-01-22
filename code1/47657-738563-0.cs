    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
      static void Main()
      {
        Regex regex = new Regex("<key>LibID</key><val>([a-fA-F0-9]{4})</val>");
        Match match = regex.Match("Before<key>LibID</key><val>A67A</val>After");
           
        if (match.Success)
        {
          Console.WriteLine("Found Match for {0}", match.Value);
          Console.WriteLine("ID was {0}", match.Groups[1].Value);
        }      
      }
    }
