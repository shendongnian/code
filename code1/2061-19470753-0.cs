    using System;
    using System.Windows.Forms;
    using System.Threading;
    namespace OneAndOnlyOne
    {
    static class Program
    {
        static String _mutexID = " // generate guid"
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Boolean _isNotRunning;
            using (Mutex _mutex = new Mutex(true, _mutexID, out _isNotRunning))
            {
                if (_isNotRunning)
                {
                    Application.Run(new Form1());
                }
                else
                {
                    MessageBox.Show("An instance is already running.");
                    return;
                }
            }
        }
    }
    }
