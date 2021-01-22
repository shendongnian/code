    var dir = new DirectoryInfo(_outputFolder);
            
    if (!dir.Exists)
    {
        dir.Create();
    }
    if ((dir.Attributes & FileAttributes.Compressed) == 0)
    {
        try
        {
            // Enable compression for the output folder
            // (this will save a ton of disk space)
            string objPath = "Win32_Directory.Name=" + "'" + dir.FullName.Replace("\\", @"\\").TrimEnd('\\') + "'";
            using (ManagementObject obj = new ManagementObject(objPath))
            {
                using (obj.InvokeMethod("Compress", null, null))
                {
                    // I don't really care about the return value, 
                    // if we enabled it great but it can also be done manually
                    // if really needed
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Trace.WriteLine("Cannot enable compression for folder '" + dir.FullName + "': " + ex.Message, "WMI");
        }
    }
