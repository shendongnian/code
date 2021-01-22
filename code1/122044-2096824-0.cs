    string name = Environment.MachineName;
    string name = System.Net.Dns.GetHostName();
    string name = System.Windows.Forms.SystemInformation.ComputerName;
    Process[] myProcesses = Process.GetProcessesByName("myExeProcName",MachineName);
    foreach(Process myProcess in myProcesses)
    {
        Console.Write("MachineName : " + myProcess.MachineName + "\n");
    }
