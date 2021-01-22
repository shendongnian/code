   static class Program
    {    
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs(); 
            string text = File.ReadAllText(args[1]);
            // ...
        }
    }
