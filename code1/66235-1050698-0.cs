        public static bool CheckReadWriteAccces(string filePath, System.Security.AccessControl.FileSystemRights fileSystemRights)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            string str = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToUpper();
            foreach (System.Security.AccessControl.FileSystemAccessRule rule in fileInfo.GetAccessControl().GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
            {
                if (str == rule.IdentityReference.Value.ToUpper())
                    return ((rule.AccessControlType == System.Security.AccessControl.AccessControlType.Allow) && (fileSystemRights == (rule.FileSystemRights & fileSystemRights)));
            }
            return false;
        }
        /// <summary>
        /// Make a file writteble
        /// </summary>
        /// <param name="path">File name to change</param>
        public static void MakeWritable(string path)
        {
            if (!File.Exists(path))
                return;
            File.SetAttributes(path, File.GetAttributes(path) & ~FileAttributes.ReadOnly);
        }
