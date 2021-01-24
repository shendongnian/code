    namespace ConsoleApplication1
    {
        class LoginSystem
        {
            public string MAP_PATH { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                LoginSystem ACGateLoginSystem = new LoginSystem();
                ACGateLoginSystem.MAP_PATH = @"D:\1.png";
    
                if (File.Exists(ACGateLoginSystem.MAP_PATH))
                    Console.WriteLine("File Exists");
                
                if (File.Exists("D:\\1.png"))
                    Console.WriteLine("File Exists - with direct path");
    
                Console.ReadLine();
            }
        }
    }
