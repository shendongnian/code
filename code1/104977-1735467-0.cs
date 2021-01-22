    namespace Simtho
    {
        class Program
        {
            static void Main(string[] args)
            {
                foreach (string arg in Environment.GetCommandLineArgs())
                {
                    switch (arg)
                    {
    
                        case "-i":
                            Console.WriteLine("Command Executed Successfully");
                            Console.Read();
                            break;
                    }
                }
            }
        }
    }
