    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                TestMethod((Choices)3);
            }
    
            private static int TestMethod(Choices choice) {
                return 1;
            }
        }
    
        public enum Choices
        {
            One = 1,
            Two = 2,
            [ObsoleteAttribute("don't use me", true)]
            Three = 3,
            Four = 4
        }
    }
