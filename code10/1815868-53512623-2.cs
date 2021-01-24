    System.Management.ManagementClass mc = default(System.Management.ManagementClass);
    ManagementObject mo = default(ManagementObject);
    mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
    
    ManagementObjectCollection moc = mc.GetInstances();
        foreach (var mo in moc) {
            if (mo.Item("IPEnabled") == true) {
                  Adapter.Items.Add("MAC " + mo.Item("MacAddress").ToString());
             }
         }
