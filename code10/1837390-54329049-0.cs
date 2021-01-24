     using System.Linq;
     ...
     private static int[] G(string sentence) {
       return Regex
         .Matches(sentence, @"\-?[0-9]+")          // \-? - if we accept negative numbers
         .OfType<Match>()                          // Matches collection to IEnumerable<Match>
         .Select(match => int.Parse(match.Value))  // each Match to int
         .ToArray();                               // Materialize to array
     }
     ...
     // result == {0, 55, 6}
     int[] result = G("0 55   6);"
