    ServiceController sc = new ServiceController();
                sc.MachineName = remoteSystem;
                sc.ServiceName = procSearc;
                
                if(sc.Status.Equals(ServiceControllerStatus.Running))
                { sc.Stop(); }
                else
                { sc.Start(); }
