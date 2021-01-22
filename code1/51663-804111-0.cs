    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Test
    {
        static void Main()
        {
            IEnumerable<char> letters = "aBCdEFghIJklMNopQRsTUvWyXZ";
            
            var query = letters.Select((c, i) => 
                                       new { Char=c, OriginalIndex=i })
                               .Where(x => char.IsLower(x.Char))
                               .Select((x, i) =>
                                       new { x.Char,
                                             x.OriginalIndex,
                                             FinalIndex=i});
            
            foreach (var result in query)
            {
                Console.WriteLine(result);
            }
        }
    }
