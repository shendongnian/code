    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Management;
    
    namespace WMITestConsolApplication
    {
    
    	class Program
    	{
    
    		static void Main(string[] args)
    		{
    
    			AddInsetUSBHandler();
    			AddRemoveUSBHandler();
    			while (true) {
    			}
    
    		}
    
    		static ManagementEventWatcher w = null;
    
    		static void AddRemoveUSBHandler()
    		{
    
    			WqlEventQuery q;
    			ManagementScope scope = new ManagementScope("root\\CIMV2");
    			scope.Options.EnablePrivileges = true;
    
    			try {
    
    				q = new WqlEventQuery();
    				q.EventClassName = "__InstanceDeletionEvent";
    				q.WithinInterval = new TimeSpan(0, 0, 3);
    				q.Condition = "TargetInstance ISA 'Win32_USBControllerdevice'";
    				w = new ManagementEventWatcher(scope, q);
    				w.EventArrived += USBRemoved;
    
    				w.Start();
    			}
    			catch (Exception e) {
    
    
    				Console.WriteLine(e.Message);
    				if (w != null)
    				{
    					w.Stop();
    
    				}
    			}
    
    		}
    
    		static void AddInsetUSBHandler()
    		{
    
    			WqlEventQuery q;
    			ManagementScope scope = new ManagementScope("root\\CIMV2");
    			scope.Options.EnablePrivileges = true;
    
    			try {
    
    				q = new WqlEventQuery();
    				q.EventClassName = "__InstanceCreationEvent";
    				q.WithinInterval = new TimeSpan(0, 0, 3);
    				q.Condition = "TargetInstance ISA 'Win32_USBControllerdevice'";
    				w = new ManagementEventWatcher(scope, q);
    				w.EventArrived += USBAdded;
    
    				w.Start();
    			}
    			catch (Exception e) {
    
    				Console.WriteLine(e.Message);
    				if (w != null)
    				{
    					w.Stop();
    
    				}
    			}
    
    		}
    
    		static void USBAdded(object sender, EventArgs e)
    		{
    
    			Console.WriteLine("A USB device inserted");
    
    		}
    
    		static void USBRemoved(object sender, EventArgs e)
    		{
    
    			Console.WriteLine("A USB device removed");
    
    		}
    	}
    
    }
