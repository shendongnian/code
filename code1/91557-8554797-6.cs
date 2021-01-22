C#
if(service.Properties["Name"].Value.ToString() == userInputValue)
{
    service.Properties["StartMode"].Value = "Automatic";
    //service.Properties["StartMode"].Value = "Manual";
}
//This will get all of the Services running on a Domain Computer and change the "Apple Mobile Device" Service to the StartMode of Automatic.  These two functions should obviously be separated, but it is simple to change a service start mode after installation using WMI
private void getServicesForDomainComputer(string computerName)
{
    ConnectionOptions co1 = new ConnectionOptions();
    co1.Impersonation = ImpersonationLevel.Impersonate;
    //this query could also be: ("select * from Win32_Service where name = '" + serviceName + "'");
    ManagementScope scope = new ManagementScope(@"\\" + computerName + @"\root\cimv2");
    scope.Options = co1;
    SelectQuery query = new SelectQuery("select * from Win32_Service");
    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
    {
        ManagementObjectCollection collection = searcher.Get();
        foreach (ManagementObject service in collection)
        {
            //the following are all of the available properties 
            //boolean AcceptPause
            //boolean AcceptStop
            //string Caption
            //uint32 CheckPoint
            //string CreationClassName
            //string Description
            //boolean DesktopInteract
            //string DisplayName
            //string ErrorControl
            //uint32 ExitCode;
            //datetime InstallDate;
            //string Name
            //string PathName
            //uint32 ProcessId
            //uint32 ServiceSpecificExitCode
            //string ServiceType
            //boolean Started
            //string StartMode
            //string StartName
            //string State
            //string Status
            //string SystemCreationClassName
            //string SystemName;
            //uint32 TagId;
            //uint32 WaitHint;
            if(service.Properties["Name"].Value.ToString() == "Apple Mobile Device")
            {
                service.Properties["StartMode"].Value = "Automatic";
            }
        }
    }         
}
I wanted to improve this response... One method to change startMode for Specified computer, service:
C#
public void changeServiceStartMode(string hostname, string serviceName, string startMode)
{
    try
    {
        ManagementObject classInstance = 
            new ManagementObject(@"\\" + hostname + @"\root\cimv2",
                                 "Win32_Service.Name='" + serviceName + "'",
                                 null);
        // Obtain in-parameters for the method
        ManagementBaseObject inParams = classInstance.GetMethodParameters("ChangeStartMode");
        // Add the input parameters.
        inParams["StartMode"] = startMode;
        // Execute the method and obtain the return values.
        ManagementBaseObject outParams = classInstance.InvokeMethod("ChangeStartMode", inParams, null);
        // List outParams
        //Console.WriteLine("Out parameters:");
        //richTextBox1.AppendText(DateTime.Now.ToString() + ": ReturnValue: " + outParams["ReturnValue"]);
    }
    catch (ManagementException err)
    {
        //richTextBox1.AppendText(DateTime.Now.ToString() + ": An error occurred while trying to execute the WMI method: " + err.Message);
    }
}
