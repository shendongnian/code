    using (var printServer = new PrintServer(string.Format(@"\\{0}", PrinterServerName)))
    {
        foreach (var queue in printServer.GetPrintQueues())
        {
            if (!queue.IsShared)
            {
                continue;
            }
            Debug.WriteLine(queue.Name);
         }
     }
