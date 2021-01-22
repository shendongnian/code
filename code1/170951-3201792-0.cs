    class Program
    {
        static int exitCode = 0;
        
        public static ExitApplication(int exitCode)
        {
            Program.exitCode = exitCode;
            Application.Exit();
        }
        public void Main()
        {
            Application.Run(new MainForm());
            Environement.Exit(exitCode);
        }
    }
    class MainForm : Form
    {
        public MainForm()
        {
            Program.ExitApplication(42);
        } 
    }
