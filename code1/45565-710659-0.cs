    using System;
    using System.Diagnostics;
    using System.Text;
    
    public class StringBuilderTest
    {            
        static void Append(string string1, string string2)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string1);
            sb.Append("----");
            sb.Append(string2);
        }
        
        static void AppendWithCapacity(string string1, string string2)
        {
            int capacity = string1.Length + string2.Length + 4;
            StringBuilder sb = new StringBuilder(capacity);
            sb.Append(string1);
            sb.Append("----");
            sb.Append(string2);
        }
    
        static void AppendFormat(string string1, string string2)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}----{1}", string1, string2);
        }
        
        static void Main(string[] args)
        {
            int size = int.Parse(args[0]);
            int iterations = int.Parse(args[1]);
            string method = args[2];
            
            Action<string,string> action;
            switch (method)
            {
                case "Append": action = Append; break;
                case "AppendWithCapacity": action = AppendWithCapacity; break;
                case "AppendFormat": action = AppendFormat; break;
                default: throw new ArgumentException();
            }
            
            string string1 = new string('x', size);
            string string2 = new string('y', size);
    
            // Make sure it's JITted
            action(string1, string2);
            GC.Collect();
            
            Stopwatch sw = Stopwatch.StartNew();
            for (int i=0; i < iterations; i++)
            {
                action(string1, string2);
            }
            sw.Stop();
            Console.WriteLine("Time: {0}ms", (int) sw.ElapsedMilliseconds);
        }
    }
