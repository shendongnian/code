    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace SO
    {
        class Program
        {
            static void Main(string[] args)
            {
                String test = "AStringInCamelCase";
                StringBuilder sb = new StringBuilder();
    
                foreach (char c in test)
                {
                    if (Char.IsUpper(c))
                    {
                        sb.Append(" ");
                    }
                    sb.Append(c);
                }
    
                if (Char.IsUpper(test[0]))
                {
                    sb.Remove(0, 1);
                }
    
                String result = sb.ToString();
                Console.WriteLine(result);
            }
        }
    }
