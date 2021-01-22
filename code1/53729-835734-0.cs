    using System;
    
    class Test
    {
        static void Main()
        {
            Console.WriteLine(ParseLeadingInt32("-1234AMP"));
            Console.WriteLine(ParseLeadingInt32("+1234AMP"));
            Console.WriteLine(ParseLeadingInt32("1234AMP"));
            Console.WriteLine(ParseLeadingInt32("-1234"));
            Console.WriteLine(ParseLeadingInt32("+1234"));
            Console.WriteLine(ParseLeadingInt32("1234"));
       }
        
        static int ParseLeadingInt32(string text)
        {
            // Declared before loop because we need the
            // final value
            int i;
            for (i=0; i < text.Length; i++)
            {
                char c = text[i];
                if (i==0 && (c=='-' || c=='+'))
                {
                    continue;
                }
                if (char.IsDigit(c))
                {
                    continue;
                }
                break;
            }
            return int.Parse(text.Substring(0, i));
        }
    }
