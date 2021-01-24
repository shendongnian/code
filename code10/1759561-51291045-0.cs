    using System;
    using System.IO;
    
    class Test
    {
        static void Main()
        {
            using (var writer = new StreamWriter("test.txt"))
            {
                Action<string> logger = writer.WriteLine;
                ExecuteDelegate(logger);
            }
        }
        
        static void ExecuteDelegate(Action<string> logger)
        {
             logger("First line");
             logger("Second line");
             logger("Third line");
        }
    }
