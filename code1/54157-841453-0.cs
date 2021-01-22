    using System;
    using System.Text;
    
    class LineBreaks
    {    
        static void Main()
        {
            Test("a\nb");
            Test("a\nb\r\nc");
            Test("a\r\nb\r\nc");
            Test("a\rb\nc");
            Test("a\r");
            Test("a\n");
            Test("a\r\n");
        }
        
        static void Test(string input)
        {
            string normalized = NormalizeLineBreaks(input);
            string debug = normalized.Replace("\r", "\\r")
                                     .Replace("\n", "\\n");
            Console.WriteLine(debug);
        }
    
        static string NormalizeLineBreaks(string input)
        {
            // Allow 10% as a rough guess of how much the string may grow.
            // If we're wrong we'll either waste space or have extra copies -
            // it will still work
            StringBuilder builder = new StringBuilder((int) (input.Length * 1.1));
            
            bool lastWasCR = false;
            
            foreach (char c in input)
            {
                if (lastWasCR)
                {
                    lastWasCR = false;
                    if (c == '\n')
                    {
                        continue; // Already written \r\n
                    }
                }
                switch (c)
                {
                    case '\r':
                        builder.Append("\r\n");
                        lastWasCR = true;
                        break;
                    case '\n':
                        builder.Append("\r\n");
                        break;
                    default:
                        builder.Append(c);
                        break;
                }
            }
            return builder.ToString();
        }
    }
