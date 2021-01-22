    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main()
        {
            string text = 
    "<i><b>It is noticeably faster.</b></i> <i><b>They take less disk space.</i>";
            Regex pattern = new Regex(@"(</[b|i|u]>)+(\s*)(<[b|i|u]>)+");
            
            Match match = pattern.Match(text);
            foreach (Group group in match.Groups)
            {
                Console.WriteLine("Next group:");
                foreach (Capture capture in group.Captures)
                {
                    Console.WriteLine("  " + capture.Value);
                }
            }
        }
    }
