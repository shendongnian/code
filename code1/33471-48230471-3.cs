    using System;
    using System.Management;
    namespace SeekCopySupportTool.Business
    {
    public class NetWorkUNCPath
    {
        // get UNC path
        public static string GetUNCPath(string path)
        {
            if (path.StartsWith(@"\\"))
            {
                return path;
            }
            ManagementObject mo = new ManagementObject();
            mo.Path = new ManagementPath(String.Format("Win32_LogicalDisk='{0}'", path));
            // DriveType 4 = Network Drive
            if (Convert.ToUInt32(mo["DriveType"]) == 4)
            {
                return Convert.ToString(mo["ProviderName"]);
            }
            // DriveType 3 = Local Drive
            else if (Convert.ToUInt32(mo["DriveType"]) == 3)
            {
                return "\\\\" + Environment.MachineName + "\\" + path.Substring(0,1) + "$";
            }
            else
            {
                return path;
            }
        }
    }
    }
