    void DirectoryMonitor_ScanStarted(object sender, MonitorEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<MonitorEventArgs>(DirectoryMonitor_ScanStarted), sender, e);
            }
            else {...}
        }
