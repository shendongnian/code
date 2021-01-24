    MessageBox.Show(
       MutexManager.CreateApplicationMutex()
                   .ToString());
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new Form1());
