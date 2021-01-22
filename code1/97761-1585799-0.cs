    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    
    class Test
    {
        static void Main()        
        {
            Regex filter = new Regex("(^[A-Z]$)|(^F[0-9]{1,2}$)");
            IEnumerable<Keys> keyList = from x in 
                    (IEnumerable<Keys>) Enum.GetValues(typeof(Keys)) 
                where filter.Match(x.ToString()).Success
                select x;
            
            foreach (var key in keyList)
            {
                Console.WriteLine(key);
            }
        }
    }
