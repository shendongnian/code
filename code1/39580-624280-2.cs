    using System.IO;
    using System.Management;
    
    class Program
    {
        static void Main(string[] args)
        {
            string destinationDir = "c:/temp/testcomp";
            DirectoryInfo directoryInfo = new DirectoryInfo(destinationDir);
            if ((directoryInfo.Attributes & FileAttributes.Compressed) != FileAttributes.Compressed)
            {
                string objPath = "Win32_Directory.Name=" + "\"" + destinationDir + "\"";
                using (ManagementObject dir = new ManagementObject(objPath))
                {
                    ManagementBaseObject outParams = dir.InvokeMethod("Compress", null, null);
                    uint ret = (uint)(outParams.Properties["ReturnValue"].Value);
                }
            }
         }
    }
