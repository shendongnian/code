    using System.Diagnostics;
            
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string [] args)
        {
            // disable these lines:
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //read settings file or parse arguments
            //start the GUI or CLI process
            Process process = new Process();
            process.StartInfo.FileName = "some.exe";
            process.Start();
            //optional
            process.WaitForExit();
        }
    }
