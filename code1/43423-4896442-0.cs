    using Microsoft.Win32;
    RegistryKey key = Registry.LocalMachine.OpenSubKey(@"System\CurrentControlSet\Control\Print\Monitors\Standard TCP/IP Port\Ports\" + printerPortName, RegistryKeyPermissionCheck.Default, System.Security.AccessControl.RegistryRights.QueryValues);
    if (key != null)
    {
        String IP = (String)key.GetValue("IPAddress", String.Empty, RegistryValueOptions.DoNotExpandEnvironmentNames);
    }
