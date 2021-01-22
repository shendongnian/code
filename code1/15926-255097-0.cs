      IntegratedServiceInstaller Inst = new IntegratedServiceInstaller();
      Inst.Install("MySvc", "My Sample Service", "Service that executes something",
                        _InstanceID,
    // System.ServiceProcess.ServiceAccount.LocalService,      // this is more secure, but only available in XP and above and WS-2003 and above
      System.ServiceProcess.ServiceAccount.LocalSystem,       // this is required for WS-2000
      System.ServiceProcess.ServiceStartMode.Automatic);
      if (controller == null)
      {
        controller = new System.ServiceProcess.ServiceController(String.Format("MySvc_{0}", _InstanceID), ".");
                    }
                    if (controller.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                    {
                        Start_Stop.Text = "Stop Service";
                        Start_Stop_Debugging.Enabled = false;
                    }
                    else
                    {
                        Start_Stop.Text = "Start Service";
                        Start_Stop_Debugging.Enabled = true;
                    }
