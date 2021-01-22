    void RegisterProcessExit(Process process)
    {
        // NOTE there will be a race condition with the caller here
        //   how to fix it is left as an exercise
        process.Exited += process_Exited;
    }
    static void process_Exited(object sender, EventArgs e)
    {
       Console.WriteLine("Process has exited.");
    }
