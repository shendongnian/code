    using System.Linq;
    using System.Management;
    public static uint PrintTestPage(string PrinterName, string MachineName)
    {
        ConnectionOptions connOptions = GetConnectionOptions();
        EnumerationOptions mOptions = GetEnumerationOptions(false);
        string machineName = string.IsNullOrEmpty(MachineName) ? Environment.MachineName : MachineName;
        ManagementScope mScope = new ManagementScope($@"\\{machineName}\root\CIMV2", connOptions);
        SelectQuery mQuery = new SelectQuery("SELECT * FROM Win32_Printer");
        mQuery.QueryString += string.IsNullOrEmpty(PrinterName) 
                            ? " WHERE Default = True" 
                            : $" WHERE Name = '{PrinterName}'";
        mScope.Connect();
        using (ManagementObjectSearcher moSearcher = new ManagementObjectSearcher(mScope, mQuery, mOptions))
        {
            ManagementObject moPrinter = moSearcher.Get().OfType<ManagementObject>().FirstOrDefault();
            if (moPrinter is null) throw new InvalidOperationException("Printer not found");
            InvokeMethodOptions moMethodOpt = new InvokeMethodOptions(null, ManagementOptions.InfiniteTimeout);
            using (ManagementBaseObject moParams = moPrinter.GetMethodParameters("PrintTestPage"))
            using (ManagementBaseObject moResult = moPrinter.InvokeMethod("PrintTestPage", moParams, moMethodOpt))
                return (UInt32)moResult["ReturnValue"];
        }
    }
