    Application.Run(new Form1()); // Calls Application.Exit()
    
    Application.Idle += (o, e) => Task.Run(() => Application.Exit());
    Application.Run();
    MessageBox.Show("I'm alive!");
