    internal struct SomeValType
        {
            public static int foo = 0;
            public int bar;
    
            static SomeValType()
            {
                Console.WriteLine("This never gets displayed");
            }
        }
    
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                // Doesn't hit static constructor
                SomeValType v = new SomeValType();
                v.bar = 1;
    
                // Hits static constructor
                SomeValType.foo = 3;
            }
        }
