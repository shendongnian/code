    bool firstInstance = true;
    using (Mutex mutex = new Mutex(true, "MyApplicationName", out firstInstance))
    {
        if (firstInstance)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        else
        {
            // Another instance loaded
        }
    }
