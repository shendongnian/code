    uint ProcessId = (uint)outParams["processId"];
        if (ProcessId != 0)
        {
            while (true)
            {
                try
                {
                    Process.GetProcessById((int)ProcessId, {your_remoteMachineName});
                    Thread.Sleep(1000);
                }
                catch
                {
                    break;                    
                }
            }
        }
