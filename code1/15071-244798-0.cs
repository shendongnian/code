    public static void SetPermissions(string dir)
            {
                DirectoryInfo info = new DirectoryInfo(dir);
                DirectorySecurity ds = info.GetAccessControl();            
                ds.AddAccessRule(new FileSystemAccessRule(@"BUILTIN\Users", 
                                 FileSystemRights.FullControl,
                                 InheritanceFlags.ObjectInherit |
                                 InheritanceFlags.ContainerInherit,
                                 PropagationFlags.None,
                                 AccessControlType.Allow));
                info.SetAccessControl(ds);            
            }
