    using System;
    
    namespace guid
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                new MainClass().run();
            }
    
            private void run()
            {
                Console.WriteLine(Guid.NewGuid());
            }
        }
    }
