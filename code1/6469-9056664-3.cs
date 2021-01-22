    [STAThread]
    static void Main()
    {
       Mutex runOnce = null;
       if (Properties.Settings.Default.IsRestarting)
       {
          Properties.Settings.Default.IsRestarting = false;
          Properties.Settings.Default.Save();
          Thread.Sleep(3000);
       }
       try
       {
          runOnce = new Mutex(true, "SOME_MUTEX_NAME");
          if (runOnce.WaitOne(TimeSpan.Zero))
          {
             Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new Form1());
          }
       }
       finally
       {
          if (null != runOnce)
             runOnce.Close();
       }
    }
