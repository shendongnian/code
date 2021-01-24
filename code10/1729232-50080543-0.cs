    bool processing = false;
    
    void Start()
    {
        processing = true;
    
        Process p = new Process(); ;
        p.StartInfo = new System.Diagnostics.ProcessStartInfo("E:\\app\\dist\\app.exe");
        p.StartInfo.WorkingDirectory = @"\Assets\\app\\dist\\app.exe";
        p.StartInfo.CreateNoWindow = true;
        p.EnableRaisingEvents = true;
        p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        p.Exited += new EventHandler(OnProcessExit);
        p.Start();
    }
    
    private void OnProcessExit(object sender, EventArgs e)
    {
        processing = false;
    }
    
    
    void Update()
    {
        if (processing)
        {
            //Still processing. Keep reading....
        }
    }
