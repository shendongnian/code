    void Install_1_Click(object sender , RoutedEventArgs e)
    {
        RunSilentSetup("C:\app1.exe");
    }
    
    void Install_2_Click(object sender , RoutedEventArgs e)
    {
        RunSilentSetup("C:\app2.exe");
    }
    
    static bool setupIsRunning = false;
    
    void RunSilentSetup(string executableFilePath)
    {
        if(setupIsRunning)
            return;
    
        setupIsRunning = true;
        //disable both buttons
        Install_1.Enabled = false;
        Install_2.Enabled = false;
        //code that runs the setup goes here
    
        setupIsRunning = false; //set back to false when finished
        //re-enable both buttons
        Install_1.Enabled = true;
        Install_2.Enabled = true;
    }
