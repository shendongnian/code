    static Mutex mutex;
    static bool mutexCreated;
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        if (!mutexCreated)
        {
            MessageBox.Show("Alread started!");
            Shutdown();
        }
    }
    static App()
    {
        mutex = new Mutex(true, Assembly.GetCallingAssembly().FullName, out mutexCreated);
    }
