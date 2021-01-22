static class Program
{
    public static Form1 form1; // = new Form1(); // Place this var out of the constructor
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form1 = new Form1());
        }
    }
