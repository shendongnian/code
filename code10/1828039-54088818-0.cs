    VMTypes.PlacementSpec vmPlacementSpec = new VMTypes.PlacementSpec();
            VMTypes.FilterSpec VMFilterSpec = new VMTypes.FilterSpec();
            HashSet<string> datacenters = new HashSet<string>
            {
                GetDatacenter(serviceManager, vmModel.DataCenterName)
            };
            VMFilterSpec.SetNames(new HashSet<String> { vmModel.vmName });
            VMFilterSpec.SetDatacenters(datacenters);
            VM vmservice = serviceManager.VapiConnection.GetService<VM>();
            List<VMTypes.Summary> vmsummarize = vmservice.List(VMFilterSpec);
            if (vmsummarize.Count >= 0)
            {
                string Vm_Id = vmsummarize[0].GetVm();
                if (Vm_Id != null)
                {
                    Power power = serviceManager.VapiConnection.GetService<Power>();
                    Network netWork = serviceManager.VapiConnection.GetService<Network>();
                    PowerTypes.Info powertype = power.Get(Vm_Id);
                    if (powertype.GetState().Name == "POWERED_ON")
                    {
                        Console.WriteLine("Power Off starting ");
                        power.Stop(Vm_Id);
                        Console.WriteLine("Powered Off Now ");
                        VMTypes.Info VMConfigInfo = vmservice.Get(Vm_Id);
                        Dictionary<string, EthernetTypes.Info> dictOfEthernetAdapters = VMConfigInfo.GetNics();
                        foreach (var item in dictOfEthernetAdapters)
                        {
                            EthernetTypes.Info NetworkDetails = item.Value;
                            NetworkDetails.SetWakeOnLanEnabled(false);
                            NetworkDetails.SetState(ConnectionState.UNRECOVERABLE_ERROR);
                            NetworkDetails.SetStartConnected(false);
                            NetworkDetails.SetAllowGuestControl(false);
                        }
                        Console.WriteLine("Power ON starting ");
                        power.Start(Vm_Id);
                        Console.WriteLine("Powered ON Now ");
                    }
                    else if (powertype.GetState().Name == "POWERED_OFF")
                    {
                        VMTypes.Info VMConfigInfo = vmservice.Get(Vm_Id);
                        Dictionary<string, EthernetTypes.Info> dictOfEthernetAdapters = VMConfigInfo.GetNics();
                        foreach (var item in dictOfEthernetAdapters)
                        {
                            EthernetTypes.Info NetworkDetails = item.Value;
                            NetworkDetails.SetWakeOnLanEnabled(false);
                            NetworkDetails.SetState(ConnectionState.UNRECOVERABLE_ERROR);
                            NetworkDetails.SetStartConnected(false);
                            NetworkDetails.SetAllowGuestControl(false);
                        }
                        Console.WriteLine("Powered ON started ");
                        power.Start(Vm_Id);
                        Console.WriteLine("Powered ON Now ");
                    }
                }
            }
            else
            {
                Console.WriteLine("Index was out of range");
            }
