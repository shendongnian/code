    Application.Run(new Form1()); // Calls Application.Exit() multiple times
    
    bool done = false;
    while(!done)
    {
        // Application.Idle is cleared after each run
        Application.Idle += (o, e) =>
        {
            done = true;
            Task.Run(() => Application.Exit());
        };
        Application.Run();
    }
    MessageBox.Show("I'm alive!");
