    //import in the declaration for GenerateConsoleCtrlEvent
    [DllImport("kernel32.dll", SetLastError=true)]  
    static extern bool GenerateConsoleCtrlEvent(ConsoleCtrlEvent sigevent, int dwProcessGroupId);
    public enum ConsoleCtrlEvent  
    {  
        CTRL_C = 0,  
        CTRL_BREAK = 1,  
        CTRL_CLOSE = 2,  
        CTRL_LOGOFF = 5,  
        CTRL_SHUTDOWN = 6  
    }
    //set up the parents CtrlC event handler, so we can ignore the event while sending to the child
    public static volatile bool SENDING_CTRL_C_TO_CHILD = false;
    static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
    {
        e.Cancel = SENDING_CTRL_C_TO_CHILD;
    }
    //the main method..
    static int Main(string[] args)
    {
        //hook up the event handler in the parent
        Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
        //spawn some child process
        System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
        psi.Arguments = "childProcess.exe";
        Process p = new Process();
        p.StartInfo = psi;
        p.Start();
        //sned the ctrl-c to the process group (the parent will get it too!)
        SENDING_CTRL_C_TO_CHILD = true;
        GenerateConsoleCtrlEvent(ConsoleCtrlEvent.CTRL_C, p.SessionId);        
        p.WaitForExit();
        SENDING_CTRL_C_TO_CHILD = false;
        //note that the ctrl-c event will get called on the parent on background thread
        //so you need to be sure the parent has handled and checked SENDING_CTRL_C_TO_CHILD
        already before setting it to false. 1000 ways to do this, obviously.
        //get out....
        return 0;
    }
    
