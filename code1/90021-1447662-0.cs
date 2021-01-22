    using System;
    using System.Text.RegularExpressions;
    
    namespace Test
    {
      class Test
      {
        static void Main(string[] args)
        {
          string target = @"<something><or><other>";
    
          // One group, many matches
          Regex r1 = new Regex(@"<(\w+)>");
          MatchCollection mc = r1.Matches(target);
          foreach (Match m in mc)
          {
            Console.WriteLine(m.Groups[1].Value);
          }
          Console.WriteLine();
    
          // One match, many groups
          Regex r2 = new Regex(@"<(\w+)><(\w+)><(\w+)>");
          Match m2 = r2.Match(target);
          if (m2.Success)
          {
            foreach (Group g in m2.Groups)
            {
              Console.WriteLine(g.Value);
            }
          }
          Console.WriteLine();
    
          // One group, one match, many captures
          Regex r3 = new Regex(@"(?:<(\w+)>)+");
          Match m3 = r3.Match(target);
          if (m3.Success)
          {
            foreach (Capture c in m3.Groups[1].Captures)
            {
              Console.WriteLine(c.Value);
            }
          }
          Console.WriteLine();
    
          // Many matches, no groups, no captures
          Regex r4 = new Regex(@"(?<=<)\w+(?=>)");
          foreach (Match m in r4.Matches(target))
          {
            Console.WriteLine(m.Value);
          }
          Console.ReadLine();
        }
      }
    }
