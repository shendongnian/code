    public class WindowsServiceInstallerEx : ServiceInstaller
    {
      [ComponentModel.Description("A lengthy description of the service that will display in the Description column of the Services MMC applet.")]
      public string ServiceDescription
      {
        get { return serviceDescription; }
        set { serviceDescription = value; }
      }
      public override void Install(System.Collections.IDictionary stateSaver)
      {
        base.Install (stateSaver);
        Microsoft.Win32.RegistryKey serviceKey = null;
        try
        {
          string strKey = string.Format(@"System\CurrentControlSet\Services\{0}", this.ServiceName);
          serviceKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(strKey, true);
          serviceKey.SetValue("Description", this.ServiceDescription);
        }
        finally
        {
          if (serviceKey != null)
            serviceKey.Close();
        }
      }
      private string serviceDescription;
    }
