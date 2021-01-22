    using System;
    
    namespace MyNamespace
    {
        public class Program
        {
            static void Main(string[] args)
            {
                MessageWriter.Write();          // writes "MyNamespace namespace"
                global::MessageWriter.Write();  // writes "Global namespace"
                Console.ReadLine();
            }
        }
    
        // This class is in the namespace "MyNamespace"
        public class MessageWriter
        {
            public static void Write()
            {
                Console.WriteLine("MyNamespace namespace");
            }
        }
    }
    
    // This class is in the global namespace (i.e. no specified namespace)
    public class MessageWriter
    {
        public static void Write()
        {
            Console.WriteLine("Global namespace");
        }
    }
