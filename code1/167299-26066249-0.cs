        public static void CopyFile(string source, string destination)
        {
            // Copy the file
            File.Copy(source, destination, true);
            // Get the source file's ACLs
            FileSecurity fileSecuritySource = File.GetAccessControl(source, AccessControlSections.All);
            string sddlSource = fileSecuritySource.GetSecurityDescriptorSddlForm(AccessControlSections.All);
 
            // Create the destination file's ACLs
            FileSecurity fileSecurityDestination = new FileSecurity();
            fileSecurityDestination.SetSecurityDescriptorSddlForm(sddlSource);
            // Set the destination file's ACLs
            File.SetAccessControl(destination, fileSecurityDestination);
           
            // copy the file attributes now
            FileAttributes fileAttributes = File.GetAttributes(source);
            File.SetAttributes(destination, fileAttributes);
        }
