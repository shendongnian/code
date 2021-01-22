    Application.Run(new Form1()); // Calls Application.Exit()
    
    Application.Idle += (o, e) => Application.Exit();
    Application.Run();
    MessageBox.Show("Close, but no banana...");
