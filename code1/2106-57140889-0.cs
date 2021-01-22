    static Mutex mutex = null;
    //A string that is the name of the mutex
    string mutexName = @"Global\test";
    //Prevent Multiple Instances of Application
    bool onlyInstance = false;
    mutex = new Mutex(true, mutexName, out onlyInstance);
    if (!onlyInstance)
    {
      MessageBox.Show("You are already running this application in your system.", "Already Running..", MessageBoxButton.OK);
      Application.Current.Shutdown();
    }
