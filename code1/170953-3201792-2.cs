    class Program
    {
        static int exitCode = 0;
        
        public static void ExitApplication(int exitCode)
        {
            Program.exitCode = exitCode;
            Application.Exit();
        }
        public int Main()
        {
            Application.Run(new MainForm());
            return exitCode;
        }
    }
    class MainForm : Form
    {
        public MainForm()
        {
            Program.ExitApplication(42);
        } 
    }
