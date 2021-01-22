    ServiceController sc = new ServiceController();
                sc.MachineName = bMachineNameIn;
                sc.ServiceName = remoteSystem;
                
                if(sc.Status.Equals(ServiceControllerStatus.Running))
                { sc.Stop(); }
                else
                { sc.Start(); }
