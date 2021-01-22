    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var application = new WindowsFormsApplication();
            application.Run(new Form1());
        }
    }
