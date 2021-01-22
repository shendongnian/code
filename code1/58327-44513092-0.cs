     /// <summary>
            /// The main entry point for the application.
            /// Limit an app.to one instance
            /// </summary>
            [STAThread]
            static void Main()
            {
                //Mutex to make sure that your application isn't already running.
                Mutex mutex = new System.Threading.Mutex(false, "MyUniqueMutexName");
                try
                {
                    if (mutex.WaitOne(0, false))
                    {
                        // Run the application
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Form1());
                    }
                    else
                    {
                        MessageBox.Show("An instance of the application is already running.",
                            "An Application Is Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Application Error 'MyUniqueMutexName'", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    if (mutex != null)
                    {
                        mutex.Close();
                        mutex = null;
                    }
                }
            }
