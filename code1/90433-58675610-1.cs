    //Get windows service status
        public static string GetServiceStatus(string NameOfService)
        {
            ServiceController sc = new ServiceController(NameOfService);
            switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    return "Running";
                case ServiceControllerStatus.Stopped:
                    return "Stopped";
                case ServiceControllerStatus.Paused:
                    return "Paused";
                case ServiceControllerStatus.StopPending:
                    return "Stopping";
                case ServiceControllerStatus.StartPending:
                    return "Starting";
                default:
                    return "Status Changing";
            }
        }
        //finds if service exists in OS
        public static bool DoesServiceExist(string serviceName)
        {
            return ServiceController.GetServices().Any(serviceController => serviceController.ServiceName.Equals(serviceName));
        }
        //finds startup type of service
        public static string GetStartupType(string serviceName)
        {
            ManagementObject objManage = new ManagementObject("Win32_Service.Name='"+serviceName+"'");
            objManage.Get();
            string status1 = objManage["StartMode"].ToString();
            return status1;
        }
        //restart service through PID
        public static bool RestartServiceByPID(string NameOfService)
        {
            LogWriter log = new LogWriter("TaskKilling: " + NameOfService);
            string strCmdText = "/C taskkill /f /fi \"SERVICES eq " + NameOfService + "\"";
            Process.Start("CMD.exe", strCmdText);
            using(ServiceController ScvController = new ServiceController(NameOfService))
            {
                ScvController.WaitForStatus(ServiceControllerStatus.Stopped);
                if (GetServiceStatus(NameOfService) == "Stopped")
                {
                    ScvController.Start();
                    ScvController.WaitForStatus(ServiceControllerStatus.Running);
                    if (GetServiceStatus(NameOfService) == "Running")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        //Restart windows service
        public static bool RestartWindowsService(string NameOfService)
        {
            try
            {
                //check if service exists
                if(DoesServiceExist(NameOfService) == false)
                {
                    MessageBox.Show("Service " + NameOfService + " was not found.");
                    return false;
                }
                else
                {
                    //if it does it check startup type and if it is disabled it will set it to "Auto"
                    if (GetStartupType(NameOfService) == "Disabled")
                    {
                        using (var svc = new ServiceController(NameOfService))
                        {
                            ServiceHelper.ChangeStartMode(svc, ServiceStartMode.Automatic);
                            if (svc.Status != ServiceControllerStatus.Running)
                            {
                                svc.Start();
                                svc.WaitForStatus(ServiceControllerStatus.Running);
                                if(GetServiceStatus(NameOfService) == "Running")
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                svc.Stop();
                                svc.WaitForStatus(ServiceControllerStatus.Stopped);
                                if(GetServiceStatus(NameOfService) == "Stopped")
                                {
                                    svc.Start();
                                    svc.WaitForStatus(ServiceControllerStatus.Running);
                                    if(GetServiceStatus(NameOfService) == "Running")
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                //restart through PID
                                else
                                {
                                    return RestartServiceByPID(NameOfService);
                                }
                            }
                        }
                    }
                    //If service is not disabled it will restart it
                    else
                    {
                        using(ServiceController ScvController = new ServiceController(NameOfService))
                        {
                            if(GetServiceStatus(NameOfService) == "Running")
                            {
                                ScvController.Stop();
                                ScvController.WaitForStatus(ServiceControllerStatus.Stopped);
                                if(GetServiceStatus(NameOfService) == "Stopped")
                                {
                                    ScvController.Start();
                                    ScvController.WaitForStatus(ServiceControllerStatus.Running);
                                    if(GetServiceStatus(NameOfService) == "Running")
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                //if stopping service fails, it uses taskkill
                                else
                                {
                                    return RestartServiceByPID(NameOfService);
                                }
                            }
                            else
                            {
                                ScvController.Start();
                                ScvController.WaitForStatus(ServiceControllerStatus.Running);
                                if(GetServiceStatus(NameOfService) == "Running")
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return RestartServiceByPID(NameOfService);
            }
        }
