	using System;
	using System.ComponentModel;
	using System.Runtime.InteropServices;
	using System.Management;
	class UsbWatcher 
	{
		public static void Main() 
		{
			WMIEvent wEvent = new WMIEvent();
			ManagementEventWatcher watcher = null;
			WqlEventQuery query;
			ManagementOperationObserver observer = new ManagementOperationObserver();
			
			ManagementScope scope = new ManagementScope("root\\CIMV2");
			scope.Options.EnablePrivileges = true; 
			try 
			{
				query = new WqlEventQuery();
				query.EventClassName = "__InstanceCreationEvent";
				query.WithinInterval = new TimeSpan(0,0,10);
				query.Condition = @"TargetInstance ISA 'Win32_USBControllerDevice' ";
				watcher = new ManagementEventWatcher(scope, query);
				watcher.EventArrived 
					+= new EventArrivedEventHandler(wEvent.UsbEventArrived);
				watcher.Start();
			}
			catch (Exception e)
			{
				//handle exception
			}
	}
