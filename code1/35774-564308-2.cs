    using System;
    
    class Test
    {
        static void Main()
        {
            TestParsing("24/10/2009");
            TestParsing("flibble");
        }
        
        static void TestParsing(string text)
        {
            DateTime dt;
            
            if (DateTime.TryParseExact(text, "d", null, 0, out dt))
            {
                Console.WriteLine("Parsed to {0}", dt);
            }
            else
            {
                Console.WriteLine("Bad date");
            }
        }
    }
