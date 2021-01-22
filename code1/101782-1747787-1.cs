            try
            {
                WqlEventQuery q = new WqlEventQuery();
                q.EventClassName = "__InstanceModificationEvent";
                q.WithinInterval = new TimeSpan(0, 0, 1);
                q.Condition = @"TargetInstance ISA 'Win32_LogicalDisk' and TargetInstance.DriveType = 5";
                ConnectionOptions opt = new ConnectionOptions();
                opt.EnablePrivileges = true;
                opt.Authority = null;
                opt.Authentication = AuthenticationLevel.Default;
                //opt.Username = "Administrator";
                //opt.Password = "";
                ManagementScope scope = new ManagementScope("\\root\\CIMV2", opt);
                ManagementEventWatcher watcher = new ManagementEventWatcher(scope, q);
                watcher.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
                watcher.Start();
            }
            catch (ManagementException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject wmiDevice = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            string driveName = (string)wmiDevice["DeviceID"];
            Console.WriteLine(driveName);
            Console.WriteLine(wmiDevice.Properties["VolumeName"].Value);
            Console.WriteLine((string)wmiDevice["Name"]);
            if (wmiDevice.Properties["VolumeName"].Value != null)
                Console.WriteLine("CD has been inserted");
            else
                Console.WriteLine("CD has been ejected");
        }
