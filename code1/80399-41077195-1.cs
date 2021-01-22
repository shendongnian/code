    private static void GrantAccess(string file)
            {
                bool exists = System.IO.Directory.Exists(file);
                if (!exists)
                {
                    DirectoryInfo di = System.IO.Directory.CreateDirectory(file);
                    Console.WriteLine("The Folder is created Sucessfully");
                }
                else
                {
                    Console.WriteLine("The Folder already exists");
                }
                DirectoryInfo dInfo = new DirectoryInfo(file);
                DirectorySecurity dSecurity = dInfo.GetAccessControl();
                dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                dInfo.SetAccessControl(dSecurity);
    
            }
