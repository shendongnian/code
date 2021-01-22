    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "012345678901234567890";
                int remaining = input.Length;
    
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < input.Length; i+=10)
                {                
                    sb.Append('"').Append(input.Substring(i, Math.Min(10, remaining))).Append('"');
                    remaining -= 10;
                }
                Console.WriteLine(sb.ToString());
            }
        }
    }
