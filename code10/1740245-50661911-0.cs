    using System;
    using System.Linq;
    
    namespace SearchLinq
    {
        class Program
        {
            static void Main(string[] args)
            {
                string source = "Top Senders By Total Threat Messages";
                string find = "Incoming Mail Domains Top Senders By Total Threat Messages";
    
                // first possible solution
                int result = 0;
                foreach (string word in find.Split(' '))
                {
                    if (source.Contains(word))
                    {
                        result++;
                    }
                }
                Console.WriteLine(result);
    
                // second possible solution
                int result2 = find.Split(' ').Count(w => source.Contains(w));
                Console.WriteLine(result2);
            }
        }
    }
