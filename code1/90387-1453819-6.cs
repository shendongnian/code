    namespace TestStackOverflow
    {
        class Program
        {
            class StackOver : MarshalByRefObject
            {
                public bool Run()
                {
                    return true; // Keep the application running. (Return false to quit)
                }
            }
    
            static void Main(string[] args)
            {
                // Other code...
                while (stack.Run());
            }
    
        }
    }
