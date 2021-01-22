    using System.IO;
    using System.Management;
    using System.Security.AccessControl;
    public static void CreateFolder(String accountName, String homeFolder)
        {
            String folderName;
            String localfolderpath;
            String shareName;
            try
            {
                folderName = "\\\\server\\c$\\Home\\" + homeFolder + "\\" + accountName;
                Directory.CreateDirectory(folderName);
                localfolderpath = "C:\\Home\\" + homeFolder + "\\" + accountName;
                shareName = accountName + "$";
                FolderACL(accountName, folderName);
                makeShare(localfolderpath, shareName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
        public static void FolderACL(String accountName, String folderPath)
        {
            FileSystemRights Rights;
            //What rights are we setting?
            Rights = FileSystemRights.FullControl;
            bool modified;
            InheritanceFlags none = new InheritanceFlags();
            none = InheritanceFlags.None;
            //set on dir itself
            FileSystemAccessRule accessRule = new FileSystemAccessRule(accountName, Rights, none, PropagationFlags.NoPropagateInherit, AccessControlType.Allow);
            DirectoryInfo dInfo = new DirectoryInfo(folderPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.ModifyAccessRule(AccessControlModification.Set, accessRule, out modified);
            //Always allow objects to inherit on a directory 
            InheritanceFlags iFlags = new InheritanceFlags();
            iFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;
            //Add Access rule for the inheritance
            FileSystemAccessRule accessRule2 = new FileSystemAccessRule(accountName, Rights, iFlags, PropagationFlags.InheritOnly, AccessControlType.Allow);
            dSecurity.ModifyAccessRule(AccessControlModification.Add, accessRule2, out modified);
            dInfo.SetAccessControl(dSecurity);
        }
        private static void makeShare(string filepath, string sharename)
        {
            try
            {
                String servername = "server";
                // assemble the string so the scope represents the remote server
                string scope = string.Format("\\\\{0}\\root\\cimv2", servername);
                // connect to WMI on the remote server
                ManagementScope ms = new ManagementScope(scope);
                // create a new instance of the Win32_Share WMI object
                ManagementClass cls = new ManagementClass("Win32_Share");
                // set the scope of the new instance to that created above
                cls.Scope = ms;
                // assemble the arguments to be passed to the Create method
                object[] methodargs = { filepath, sharename, "0" };
                // invoke the Create method to create the share
                object result = cls.InvokeMethod("Create", methodargs);
                MessageBox.Show(result.ToString());
            }
            catch (SystemException e)
            {
                Console.WriteLine("Error attempting to create share {0}:", sharename);
                Console.WriteLine(e.Message);
            }
        }
