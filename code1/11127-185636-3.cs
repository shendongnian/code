    List<System.Diagnostics.Process> processList = new List<System.Diagnostics.Process>();
    try
    {
        foreach (string command in Commands)
        {
            processList.Add(System.Diagnostics.Process.Start(command));
        }
        // loop until all spawned processes Exit normally.
        while (processList.Any())
        {
            System.Threading.Thread.Sleep(1000); // wait and see.
            List<System.Diagnostics.Process> finished = (from o in processList
                                                         where o.HasExited
                                                         select o).ToList();
            processList = processList.Except(finished).ToList();
            foreach (var p in finished)
            {
                // could inspect exit code and exit time.
                p.Close();
            }
        }
    }
    catch (Exception ex)
    {
        // log the exception
        throw;
    }
    finally
    {
        foreach (var p in processList)
        {
            if (p != null)
            {
                if( !p.HasExited )
                {
                    // If you want to Kill() process instead, wrap in try{}
                    p.Close();
                }
                p.Dispose();
            }
        }
    }
