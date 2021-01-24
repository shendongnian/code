     private void RegexTest()
     {
         var regex = new Regex(@"([a-zA-Z]\w*)\s*(<|>|(={1,2})|!=)\s*([a-zA-Z]\w*)");
         var inputs = new string[]
         {
             "XYZ = XYZ",
             "ABC != A",
             "1 > 3",
             "a12 < m34"
         };
         foreach (var input in inputs)
         {
             var match = regex.Match(input);
             if (match.Length > 0)
             {
                 Debug.WriteLine($"Match for ({input}): First: {match.Groups[1]}, Comparer: {match.Groups[2]}, Second: {match.Groups[4]}");
             }
             else
             {
                 Debug.WriteLine($"No match for {input}");
             }
         }
     }
