            static Mutex mx;
            const string singleInstance = @"MU.Mutex";
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                try
                {
                    System.Threading.Mutex.OpenExisting(singleInstance);
                    MessageBox.Show("already exist instance");
                    return;
                }
                catch
                {
                    mx = new System.Threading.Mutex(true, singleInstance);
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
