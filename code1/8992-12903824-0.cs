    - STAThreadAttribute 
    That indicates that the COM threading model for an application is single-threaded apartment (STA). 
    For example this attribute is used in Windows Forms Applications:
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
