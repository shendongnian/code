    namespace Sample
    {
        using System;
        using System.Diagnostics;
        using System.Globalization;
        internal class ServiceSample
        {
            private static bool ChangeStartupType(string serviceName, string startupType)
            {
                string arguments = string.Format(
                    CultureInfo.InvariantCulture,
                    "config {0} start= {1}",
                    serviceName,
                    startupType);
                using (Process sc = Process.Start("sc.exe", arguments))
                {
                    sc.WaitForExit();
                    return sc.ExitCode == 0;
                }
            }
            private static void Main()
            {
                ServiceSample.ChangeStartupType("NetTcpPortSharing", "auto");
            }
        }
    }
