    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    internal static extern uint RegisterWindowMessage(string lpString);
    private uint CancelAutoPlay = 0;
    private void button1_Click(object sender, EventArgs e)
    {
        WqlEventQuery query = new WqlEventQuery() {
            EventClassName = "__InstanceOperationEvent",
            WithinInterval = new TimeSpan(0, 0, 3),
            Condition = @"TargetInstance ISA 'Win32_DiskDrive'"
        };
        ManagementScope scope = new ManagementScope("root\\CIMV2");
        using (ManagementEventWatcher MOWatcher = new ManagementEventWatcher(query))
        {
            MOWatcher.Options.Timeout = ManagementOptions.InfiniteTimeout;
            MOWatcher.EventArrived += new EventArrivedEventHandler(DeviceChangedEvent);
            MOWatcher.Start();
        }
    }
    private void DeviceChangedEvent(object sender, EventArrivedEventArgs e)
    {
        using (ManagementBaseObject MOBbase = (ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value)
        {
            bool DriveArrival = false;
            string EventMessage = string.Empty;
            string oInterfaceType = MOBbase.Properties["InterfaceType"]?.Value.ToString();
                
            if (e.NewEvent.ClassPath.ClassName.Equals("__InstanceDeletionEvent"))
            {
                DriveArrival = false;
                EventMessage = oInterfaceType + " Drive removed";
            }
            else
            {
                DriveArrival = true;
                EventMessage = oInterfaceType + " Drive inserted";
            }
            EventMessage += ": " + MOBbase.Properties["Caption"]?.Value.ToString();
            this.BeginInvoke((MethodInvoker)delegate { this.UpdateUI(DriveArrival, EventMessage); });
        }
    }
    private void UpdateUI(bool IsDriveInserted, string message)
    {
        if (IsDriveInserted)
            this.lblDeviceArrived.Text = message;
        else
            this.lblDeviceRemoved.Text = message;
    }
    [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (CancelAutoPlay == 0)
            CancelAutoPlay = RegisterWindowMessage("QueryCancelAutoPlay");
        if ((int)m.Msg == CancelAutoPlay) { m.Result = (IntPtr)1; }
    }
