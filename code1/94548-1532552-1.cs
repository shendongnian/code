    using System;
    
    namespace ConsoleImpersonate
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                string str = "\tid 01CA4692.A44F1F3E@blah.blah.co.uk; Tue, 6 Oct 2009 15:38:16 +0100";
                var trimmed = str.Split(';')[1].Trim();
                var x = DateTime.Parse(trimmed);
    
            }
        }
    }
