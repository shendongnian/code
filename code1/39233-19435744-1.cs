    using System.Management;
    private void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
    {
    	ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
    	foreach (var property in instance.Properties)
    	{
    		Console.WriteLine(property.Name + " = " + property.Value);
    	}
    }
    
    void DeviceRemovedEvent(object sender, EventArrivedEventArgs e)
    {
    	ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
    	foreach (var property in instance.Properties)
    	{
    		Console.WriteLine(property.Name + " = " + property.Value);
    	}
    }            
    
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
    	WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");
       
    	ManagementEventWatcher insertWatcher = new ManagementEventWatcher(insertQuery);
    	insertWatcher.EventArrived += new EventArrivedEventHandler(DeviceInsertedEvent);
    	insertWatcher.Start();
    
    	WqlEventQuery removeQuery = new WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");
    	ManagementEventWatcher removeWatcher = new ManagementEventWatcher(removeQuery);
    	removeWatcher.EventArrived += new EventArrivedEventHandler(DeviceRemovedEvent);
    	removeWatcher.Start();
    
    	// Do something while waiting for events
    	System.Threading.Thread.Sleep(20000000);
    }
