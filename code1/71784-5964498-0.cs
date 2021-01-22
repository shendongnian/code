    using Microsoft.Win32;
    
           RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
            String[] instances = (String[])rk.GetValue("InstalledInstances");
            if (instances.Length > 0)
            {
                foreach (String element in instances)
                {
                   Console.WriteLine(element);    // element is your server name                
                }
            }
