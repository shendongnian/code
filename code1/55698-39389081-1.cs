     public static void KillProcessesRemote()
        {
            string targetProcessName = "myProcess"; //Do not put 'process.exe' here just 'process'
            string targetMachine = "remotMachine"; //Target machine
            string username = "myUser"; //Username
            string password = "myPassword"; //Password
            Parallel.ForEach<Process>( //Kill all processes found
                source: System.Diagnostics.Process.GetProcessesByName(targetProcessName, targetMachine),
                body: process => {
                    process.KillRemoteProcess(username, password);
                });
        }
