    // Start a process and raise an event when done.
    myProcess.StartInfo.FileName = fileName;
    // Allows to raise event when the process is finished
    myProcess.EnableRaisingEvents = true;
    // Eventhandler wich fires when exited
    myProcess.Exited += new EventHandler(myProcess_Exited);
    // Starts the process
    myProcess.Start();
        
    // Handle Exited event and display process information.
    private void myProcess_Exited(object sender, System.EventArgs e)
    {
    Console.WriteLine(
                      $"Exit time    : {myProcess.ExitTime}\n" +
                      $"Exit code    : {myProcess.ExitCode}\n" +
                      $"Elapsed time : {elapsedTime}");
    }
