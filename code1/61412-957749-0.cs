    //Declare a static Mutex in the main form or class...
    private static Mutex _AppMutex = new Mutex(false, "MYAPP");
    
    // Check the mutex before starting up another possible instance
    [STAThread]
    static void Main(string[] args) 
    {
      if (MyForm._AppMutex.WaitOne(0, false))
      {
        Application.Run(new MyForm());
      }
      else
      {
        MessageBox.Show("Application Already Running");
      }
      Application.Exit();
    }
