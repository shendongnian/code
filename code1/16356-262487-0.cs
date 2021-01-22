    void DisplayProcessStatus(Process process)
    {
        process.Refresh();  // Important
        if(process.HasExited)
        {
            Console.WriteLine("Exited.");
        }
        else
        {
            Console.WriteLine("Running.");
        } 
    }
    
