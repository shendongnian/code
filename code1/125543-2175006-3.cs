    namespace Sample
    {
        using System;
        using System.Globalization;
        using System.Management;
        internal class ServiceSample
        {
            private static bool ChangeStartupType(string serviceName, string startupType)
            {
                const string MethodName = "ChangeStartMode";
                ManagementPath path = new ManagementPath();
                path.Server = ".";
                path.NamespacePath = @"root\CIMV2";
                path.RelativePath = string.Format(
                    CultureInfo.InvariantCulture,
                    "Win32_Service.Name='{0}'",
                    serviceName);
                using (ManagementObject serviceObject = new ManagementObject(path))
                {
                    ManagementBaseObject inputParameters = serviceObject.GetMethodParameters(MethodName);
                    inputParameters["startmode"] = startupType;
                    ManagementBaseObject outputParameters = serviceObject.InvokeMethod(MethodName, inputParameters, null);
                    return (uint)outputParameters.Properties["ReturnValue"].Value == 0;
                }
            }
            private static void Main()
            {
                ServiceSample.ChangeStartupType("NetTcpPortSharing", "Automatic");
            }
        }
    }
