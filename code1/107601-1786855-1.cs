    [STAThread]
    static void Main(string[] args)
            {
                if (args.Length == 0 && args[0] == "C") // Console
                {                    
                        // Run as console code  
                }
                else
                {
                   // Run as winforms app code
                    Application.Run(new MyForm());
                }
            }
