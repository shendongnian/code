    [DllImport("kernel32.dll", SetLastError=true)]
    private static extern int FreeConsole();    
    [STAThread]
    static void Main(string[] args)
            {
                if (args.Length == 0 && args[0] == "C") // Console
                {                    
                    // Run as console code  
                    Console.WriteLine("Running as Console App");
                    Console.WriteLine("Hit any Key to exit");
                    Console.ReadLine();
              }
                else
                {
                    //Console.SetWindowSize(1,1);
                    //string procName = Assembly.GetExecutingAssembly().FullName;
                    //ProcessStartInfo info = new ProcessStartInfo(procName );
                    //info.WindowStyle = ProcessWindowStyle.Minimized;
                    // EDIT: Thanks to Adrian Bank's answer - 
                    // a better approach is to use FreeConsole()
                    FreeConsole();
                    Application.Run(new MyForm());
                }
            }
