    [STAThread]
    static void Main() 
    {
       using(Mutex mutex = new Mutex(false, "Global\\" + appGuid))
       {
          if(!mutex.WaitOne(0, false))
          {
             MessageBox.Show("Instance already running");
             return;
          }
       
          Application.Run(new Form1());
       }
    }
    private static string appGuid = "c0a76b5a-12ab-45c5-b9d9-d693faa6e7b9";
