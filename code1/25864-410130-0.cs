    using System;
    using System.Text;
    
    namespace Splitomatic
    {
        public class Program
        {
            /// <summary>
            /// Sample Input: 
            ///    arg[0]: OU=Test4,OU=Number3,OU=Item2,OU=1
            ///    arg[1]: DC=Internal,DC=Net
            /// </summary>
            /// <param name="args"></param>
            public static void Main(string[] args)
            {
                StringBuilder builder;
                string[] containers;
                string[] parts;
    
                if (args.Length != 2)
                {
                    Console.WriteLine("Usage: <exe> <containers> <append");
                }
    
                builder = new StringBuilder(args[1]);
                parts = args[0].Split(',');
                containers = new string[parts.Length];
    
                for (int i = parts.Length - 1; i >= 0; --i)
                {
                    builder.Insert(0, ",");
                    builder.Insert(0, parts[i]);
                    containers[Math.Abs(i - parts.Length + 1)] = builder.ToString();
                }
    
                Console.WriteLine("Dumping containers[]:");
                for (int i = 0; i < containers.Length; ++i)
                {
                    Console.WriteLine("containers[{0}]: {1}", i, containers[i]);
                }
    
                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
            }
        }
    }
    
