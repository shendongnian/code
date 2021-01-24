     private static void CreateSomeFolder()
     {
            try
            {
                //Create some folder and grant full permissions
                var someFolder = "SomeDataFolderPath";
                if (Directory.Exists(someFolder)) return;
                Directory.CreateDirectory(someFolder);
                GrantAccess(someFolder);
            }
            catch (Exception ex)
            {
                log.Error("Folder Creation Error - ", ex);
            }
     }
    private static bool GrantAccess(string fullPath)
    {
       var dInfo = new DirectoryInfo(fullPath);
       var dSecurity = dInfo.GetAccessControl();
       dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
       dInfo.SetAccessControl(dSecurity);
       return true; 
    }
