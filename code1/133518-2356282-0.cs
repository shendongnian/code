    Process process = new Process();
    .
    .
    process.Exited += new EventHandler(myProcess_Exited);
    process.Start();
    
    private void myProcess_Exited(object sender, System.EventArgs e)
    {    
      eventHandled = true;
      // your logging stuff here
    }
