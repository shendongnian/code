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
