    using Microsoft.Win32; 
    RegistryKey RK = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MICROSOFT\Microsoft SQL Server");
        if(RK != null)
        {
           // It's there 
        }
        else
        {
           // It's not there 
        }
