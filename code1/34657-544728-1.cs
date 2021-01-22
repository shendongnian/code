    private enum SimpleServiceCustomCommands { KillProcess = 128 };
    protected override void OnCustomCommand(int command)
    {
        switch (command)
        {
            case (int)SimpleServiceCustomCommands.KillProcess:
                if(killProcess)
                {
                    System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("MyProcessName");
                    // Before starting the new process make sure no other MyProcessName is running.
                    foreach (System.Diagnostics.Process p in process)
                    {
                        p.Kill();
                    }
                    myProcess = System.Diagnostics.Process.Start(psi);
                }
                break;
            default:
                break;
        }
    }
