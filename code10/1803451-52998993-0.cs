    public static async Task RebootMachines(List<CHost> iHosts)
    {
        var tasks = new List<Task>();
        // Build list of Reboot calls - as a List of Tasks
        foreach(var host in iHosts)
        {
            if (host.HostType == "Machine1")
            {// machine type 1
                 task = CallRestartMachine1(host.IP);
            }
            else if (host.HostType == "Machine2")
            {// machine type 2
                task = CallRestartMachine2(host.IP);
            }
             // Add task to task list - for subsequent parallel processing
             tasks.Add(task);
        }
        // Run all tasks in task list in parallel
        await Task.WhenAll(tasks);
    }
    private static async Task CallRestartMachine1(string host)
    {// helper method: reboot machines of type 1
        //RebootByWritingAFile is method that returns a Task, you need to await it
        // that is why the compiler is warning you
        await RebootByWritingAFile(host);
    }
    private static async Task CallRestartMachine2(string host)
    {// helper method: reboot machines of type 2
        await RebootByNetwork(host);
    }
