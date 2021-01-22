    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string target_prefix = "dead";
    
                while (true)
                {
                    Guid g = Guid.NewGuid();
                    string gs = g.ToString();
                    if (gs.Substring(0, target_prefix.Length) == target_prefix)
                    {
                        Console.WriteLine("Match: " + gs);
                    }
                    else
                    {
                        //Console.WriteLine("Mismatch: " + gs);
                    }
                }
            }
        }
    }
