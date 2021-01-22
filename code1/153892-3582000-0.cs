    class UserAccessRights
    {
        /// /// This code was written by Bruce Hatt
        /// Code obtained from : http://www.codeproject.com/useritems/UserFileAccessRights.asp
        /// 
        /// This class Contains a simple answer to a 
        /// potentially complicated question "Can I read this file or can I write to this file?"
        /// 
        /// Using the "rule of least privilege", one must check not only is access granted but 
        /// is it denied at any point including a possibly recursive check of groups.
        /// 
        /// For this simple check, a look at the user and immediate groups are only checked.
        /// 
        /// This class could be expanded to identify if the applicable allow/deny rule
        /// was explicit or inherited
        /// 
        private string _path;
        //private WindowsIdentity _principal;
        private SecurityIdentifier _principalSid;
        private bool _denyAppendData = false;
        private bool _denyChangePermissions = false;
        private bool _denyCreateDirectories = false;
        private bool _denyCreateFiles = false;
        private bool _denyDelete = false;
        private bool _denyDeleteSubdirectoriesAndFiles = false;
        private bool _denyExecuteFile = false;
        private bool _denyFullControl = false;
        private bool _denyListDirectory = false;
        private bool _denyModify = false;
        private bool _denyRead = false;
        private bool _denyReadAndExecute = false;
        private bool _denyReadAttributes = false;
        private bool _denyReadData = false;
        private bool _denyReadExtendedAttributes = false;
        private bool _denyReadPermissions = false;
        private bool _denySynchronize = false;
        private bool _denyTakeOwnership = false;
        private bool _denyTraverse = false;
        private bool _denyWrite = false;
        private bool _denyWriteAttributes = false;
        private bool _denyWriteData = false;
        private bool _denyWriteExtendedAttributes = false;
        private bool _allowAppendData = false;
        private bool _allowChangePermissions = false;
        private bool _allowCreateDirectories = false;
        private bool _allowCreateFiles = false;
        private bool _allowDelete = false;
        private bool _allowDeleteSubdirectoriesAndFiles = false;
        private bool _allowExecuteFile = false;
        private bool _allowFullControl = false;
        private bool _allowListDirectory = false;
        private bool _allowModify = false;
        private bool _allowRead = false;
        private bool _allowReadAndExecute = false;
        private bool _allowReadAttributes = false;
        private bool _allowReadData = false;
        private bool _allowReadExtendedAttributes = false;
        private bool _allowReadPermissions = false;
        private bool _allowSynchronize = false;
        private bool _allowTakeOwnership = false;
        private bool _allowTraverse = false;
        private bool _allowWrite = false;
        private bool _allowWriteAttributes = false;
        private bool _allowWriteData = false;
        private bool _allowWriteExtendedAttributes = false;
        public bool CanAppendData { get { return !_denyAppendData && _allowAppendData; } }
        public bool CanChangePermissions { get { return !_denyChangePermissions && _allowChangePermissions; } }
        public bool CanCreateDirectories { get { return !_denyCreateDirectories && _allowCreateDirectories; } }
        public bool CanCreateFiles { get { return !_denyCreateFiles && _allowCreateFiles; } }
        public bool CanDelete { get { return !_denyDelete && _allowDelete; } }
        public bool CanDeleteSubdirectoriesAndFiles { get { return !_denyDeleteSubdirectoriesAndFiles && _allowDeleteSubdirectoriesAndFiles; } }
        public bool CanExecuteFile { get { return !_denyExecuteFile && _allowExecuteFile; } }
        public bool CanFullControl { get { return !_denyFullControl && _allowFullControl; } }
        public bool CanListDirectory { get { return !_denyListDirectory && _allowListDirectory; } }
        public bool CanModify { get { return !_denyModify && _allowModify; } }
        public bool CanRead { get { return !_denyRead && _allowRead; } }
        public bool CanReadAndExecute { get { return !_denyReadAndExecute && _allowReadAndExecute; } }
        public bool CanReadAttributes { get { return !_denyReadAttributes && _allowReadAttributes; } }
        public bool CanReadData { get { return !_denyReadData && _allowReadData; } }
        public bool CanReadExtendedAttributes { get { return !_denyReadExtendedAttributes && _allowReadExtendedAttributes; } }
        public bool CanReadPermissions { get { return !_denyReadPermissions && _allowReadPermissions; } }
        public bool CanSynchronize { get { return !_denySynchronize && _allowSynchronize; } }
        public bool CanTakeOwnership { get { return !_denyTakeOwnership && _allowTakeOwnership; } }
        public bool CanTraverse { get { return !_denyTraverse && _allowTraverse; } }
        public bool CanWrite { get { return !_denyWrite && _allowWrite; } }
        public bool CanWriteAttributes { get { return !_denyWriteAttributes && _allowWriteAttributes; } }
        public bool CanWriteData { get { return !_denyWriteData && _allowWriteData; } }
        public bool CanWriteExtendedAttributes { get { return !_denyWriteExtendedAttributes && _allowWriteExtendedAttributes; } }
        /// /// Simple accessor
    /*        public WindowsIdentity GetWindowsIdentity
        { 
            get { return _principal; } 
        }*/
        /// /// Simple accessor
        public String GetPath
        {
            get { return _path; }
        }
        public UserAccessRights(string path, string UserId)
        {
            if ((!String.IsNullOrEmpty(UserId)) && !String.IsNullOrEmpty(path))
            {
                NTAccount n = new NTAccount(UserId);
                _principalSid = (SecurityIdentifier)n.Translate(typeof(SecurityIdentifier));
                this._path = path;
                System.IO.FileInfo fi = new System.IO.FileInfo(_path);
                AuthorizationRuleCollection acl = fi.GetAccessControl().GetAccessRules(true, true, typeof(SecurityIdentifier));
                for (int i = 0; i < acl.Count; i++)
                {
                    System.Security.AccessControl.FileSystemAccessRule rule = (System.Security.AccessControl.FileSystemAccessRule)acl[i];
                    if (_principalSid.Equals(rule.IdentityReference))
                    {
                        if (System.Security.AccessControl.AccessControlType.Deny.Equals(rule.AccessControlType))
                        {
                            if (Contains(FileSystemRights.AppendData, rule)) _denyAppendData = true;
                            if (Contains(FileSystemRights.ChangePermissions, rule)) _denyChangePermissions = true;
                            if (Contains(FileSystemRights.CreateDirectories, rule)) _denyCreateDirectories = true;
                            if (Contains(FileSystemRights.CreateFiles, rule)) _denyCreateFiles = true;
                            if (Contains(FileSystemRights.Delete, rule)) _denyDelete = true;
                            if (Contains(FileSystemRights.DeleteSubdirectoriesAndFiles, rule)) _denyDeleteSubdirectoriesAndFiles = true;
                            if (Contains(FileSystemRights.ExecuteFile, rule)) _denyExecuteFile = true;
                            if (Contains(FileSystemRights.FullControl, rule)) _denyFullControl = true;
                            if (Contains(FileSystemRights.ListDirectory, rule)) _denyListDirectory = true;
                            if (Contains(FileSystemRights.Modify, rule)) _denyModify = true;
                            if (Contains(FileSystemRights.Read, rule)) _denyRead = true;
                            if (Contains(FileSystemRights.ReadAndExecute, rule)) _denyReadAndExecute = true;
                            if (Contains(FileSystemRights.ReadAttributes, rule)) _denyReadAttributes = true;
                            if (Contains(FileSystemRights.ReadData, rule)) _denyReadData = true;
                            if (Contains(FileSystemRights.ReadExtendedAttributes, rule)) _denyReadExtendedAttributes = true;
                            if (Contains(FileSystemRights.ReadPermissions, rule)) _denyReadPermissions = true;
                            if (Contains(FileSystemRights.Synchronize, rule)) _denySynchronize = true;
                            if (Contains(FileSystemRights.TakeOwnership, rule)) _denyTakeOwnership = true;
                            if (Contains(FileSystemRights.Traverse, rule)) _denyTraverse = true;
                            if (Contains(FileSystemRights.Write, rule)) _denyWrite = true;
                            if (Contains(FileSystemRights.WriteAttributes, rule)) _denyWriteAttributes = true;
                            if (Contains(FileSystemRights.WriteData, rule)) _denyWriteData = true;
                            if (Contains(FileSystemRights.WriteExtendedAttributes, rule)) _denyWriteExtendedAttributes = true;
                        }
                        else if (System.Security.AccessControl.AccessControlType.Allow.Equals(rule.AccessControlType))
                        {
                            if (Contains(FileSystemRights.AppendData, rule)) _allowAppendData = true;
                            if (Contains(FileSystemRights.ChangePermissions, rule)) _allowChangePermissions = true;
                            if (Contains(FileSystemRights.CreateDirectories, rule)) _allowCreateDirectories = true;
                            if (Contains(FileSystemRights.CreateFiles, rule)) _allowCreateFiles = true;
                            if (Contains(FileSystemRights.Delete, rule)) _allowDelete = true;
                            if (Contains(FileSystemRights.DeleteSubdirectoriesAndFiles, rule)) _allowDeleteSubdirectoriesAndFiles = true;
                            if (Contains(FileSystemRights.ExecuteFile, rule)) _allowExecuteFile = true;
                            if (Contains(FileSystemRights.FullControl, rule)) _allowFullControl = true;
                            if (Contains(FileSystemRights.ListDirectory, rule)) _allowListDirectory = true;
                            if (Contains(FileSystemRights.Modify, rule)) _allowModify = true;
                            if (Contains(FileSystemRights.Read, rule)) _allowRead = true;
                            if (Contains(FileSystemRights.ReadAndExecute, rule)) _allowReadAndExecute = true;
                            if (Contains(FileSystemRights.ReadAttributes, rule)) _allowReadAttributes = true;
                            if (Contains(FileSystemRights.ReadData, rule)) _allowReadData = true;
                            if (Contains(FileSystemRights.ReadExtendedAttributes, rule)) _allowReadExtendedAttributes = true;
                            if (Contains(FileSystemRights.ReadPermissions, rule)) _allowReadPermissions = true;
                            if (Contains(FileSystemRights.Synchronize, rule)) _allowSynchronize = true;
                            if (Contains(FileSystemRights.TakeOwnership, rule)) _allowTakeOwnership = true;
                            if (Contains(FileSystemRights.Traverse, rule)) _allowTraverse = true;
                            if (Contains(FileSystemRights.Write, rule)) _allowWrite = true;
                            if (Contains(FileSystemRights.WriteAttributes, rule)) _allowWriteAttributes = true;
                            if (Contains(FileSystemRights.WriteData, rule)) _allowWriteData = true;
                            if (Contains(FileSystemRights.WriteExtendedAttributes, rule)) _allowWriteExtendedAttributes = true;
                        }
                    }
                }
                /*
                IdentityReferenceCollection groups = _principal.Groups;
                for (int j = 0; j < groups.Count; j++)
                {
                    for (int i = 0; i < acl.Count; i++)
                    {
                        System.Security.AccessControl.FileSystemAccessRule rule = (System.Security.AccessControl.FileSystemAccessRule)acl[i];
                        if (groups[j].Equals(rule.IdentityReference))
                        {
                            if (System.Security.AccessControl.AccessControlType.Deny.Equals(rule.AccessControlType))
                            {
                                if (Contains(FileSystemRights.AppendData, rule)) _denyAppendData = true;
                                if (Contains(FileSystemRights.ChangePermissions, rule)) _denyChangePermissions = true;
                                if (Contains(FileSystemRights.CreateDirectories, rule)) _denyCreateDirectories = true;
                                if (Contains(FileSystemRights.CreateFiles, rule)) _denyCreateFiles = true;
                                if (Contains(FileSystemRights.Delete, rule)) _denyDelete = true;
                                if (Contains(FileSystemRights.DeleteSubdirectoriesAndFiles, rule)) _denyDeleteSubdirectoriesAndFiles = true;
                                if (Contains(FileSystemRights.ExecuteFile, rule)) _denyExecuteFile = true;
                                if (Contains(FileSystemRights.FullControl, rule)) _denyFullControl = true;
                                if (Contains(FileSystemRights.ListDirectory, rule)) _denyListDirectory = true;
                                if (Contains(FileSystemRights.Modify, rule)) _denyModify = true;
                                if (Contains(FileSystemRights.Read, rule)) _denyRead = true;
                                if (Contains(FileSystemRights.ReadAndExecute, rule)) _denyReadAndExecute = true;
                                if (Contains(FileSystemRights.ReadAttributes, rule)) _denyReadAttributes = true;
                                if (Contains(FileSystemRights.ReadData, rule)) _denyReadData = true;
                                if (Contains(FileSystemRights.ReadExtendedAttributes, rule)) _denyReadExtendedAttributes = true;
                                if (Contains(FileSystemRights.ReadPermissions, rule)) _denyReadPermissions = true;
                                if (Contains(FileSystemRights.Synchronize, rule)) _denySynchronize = true;
                                if (Contains(FileSystemRights.TakeOwnership, rule)) _denyTakeOwnership = true;
                                if (Contains(FileSystemRights.Traverse, rule)) _denyTraverse = true;
                                if (Contains(FileSystemRights.Write, rule)) _denyWrite = true;
                                if (Contains(FileSystemRights.WriteAttributes, rule)) _denyWriteAttributes = true;
                                if (Contains(FileSystemRights.WriteData, rule)) _denyWriteData = true;
                                if (Contains(FileSystemRights.WriteExtendedAttributes, rule)) _denyWriteExtendedAttributes = true;
                            }
                            else if (System.Security.AccessControl.AccessControlType.Allow.Equals(rule.AccessControlType))
                            {
                                if (Contains(FileSystemRights.AppendData, rule)) _allowAppendData = true;
                                if (Contains(FileSystemRights.ChangePermissions, rule)) _allowChangePermissions = true;
                                if (Contains(FileSystemRights.CreateDirectories, rule)) _allowCreateDirectories = true;
                                if (Contains(FileSystemRights.CreateFiles, rule)) _allowCreateFiles = true;
                                if (Contains(FileSystemRights.Delete, rule)) _allowDelete = true;
                                if (Contains(FileSystemRights.DeleteSubdirectoriesAndFiles, rule)) _allowDeleteSubdirectoriesAndFiles = true;
                                if (Contains(FileSystemRights.ExecuteFile, rule)) _allowExecuteFile = true;
                                if (Contains(FileSystemRights.FullControl, rule)) _allowFullControl = true;
                                if (Contains(FileSystemRights.ListDirectory, rule)) _allowListDirectory = true;
                                if (Contains(FileSystemRights.Modify, rule)) _allowModify = true;
                                if (Contains(FileSystemRights.Read, rule)) _allowRead = true;
                                if (Contains(FileSystemRights.ReadAndExecute, rule)) _allowReadAndExecute = true;
                                if (Contains(FileSystemRights.ReadAttributes, rule)) _allowReadAttributes = true;
                                if (Contains(FileSystemRights.ReadData, rule)) _allowReadData = true;
                                if (Contains(FileSystemRights.ReadExtendedAttributes, rule)) _allowReadExtendedAttributes = true;
                                if (Contains(FileSystemRights.ReadPermissions, rule)) _allowReadPermissions = true;
                                if (Contains(FileSystemRights.Synchronize, rule)) _allowSynchronize = true;
                                if (Contains(FileSystemRights.TakeOwnership, rule)) _allowTakeOwnership = true;
                                if (Contains(FileSystemRights.Traverse, rule)) _allowTraverse = true;
                                if (Contains(FileSystemRights.Write, rule)) _allowWrite = true;
                                if (Contains(FileSystemRights.WriteAttributes, rule)) _allowWriteAttributes = true;
                                if (Contains(FileSystemRights.WriteData, rule)) _allowWriteData = true;
                                if (Contains(FileSystemRights.WriteExtendedAttributes, rule)) _allowWriteExtendedAttributes = true;
                            }
                        }
                    }
                }
                */
            }
        }
        /// /// Simply displays all allowed rights
        /// 
        /// Useful if say you want to test for write access and find
        /// it is false;
        /// <xmp> /// UserFileAccessRights rights = new UserFileAccessRights(txtLogPath.Text);
        /// System.IO.FileInfo fi = new System.IO.FileInfo(txtLogPath.Text);
        /// if (rights.canWrite() && rights.canRead()) {
        /// lblLogMsg.Text = "R/W access";
        /// } else {
        /// if (rights.canWrite()) {
        /// lblLogMsg.Text = "Only Write access";
        /// } else if (rights.canRead()) {
        /// lblLogMsg.Text = "Only Read access";
        /// } else {
        /// lblLogMsg.CssClass = "error";
        /// lblLogMsg.Text = rights.ToString()
        /// }
        /// }
        /// 
        /// </xmp> /// 
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (CanAppendData) { if (sb.Length != 0) sb.Append(","); sb.Append("AppendData"); }
            if (CanChangePermissions) { if (sb.Length != 0) sb.Append(","); sb.Append("ChangePermissions"); }
            if (CanCreateDirectories) { if (sb.Length != 0) sb.Append(","); sb.Append("CreateDirectories"); }
            if (CanCreateFiles) { if (sb.Length != 0) sb.Append(","); sb.Append("CreateFiles"); }
            if (CanDelete) { if (sb.Length != 0) sb.Append(","); sb.Append("Delete"); }
            if (CanDeleteSubdirectoriesAndFiles) { if (sb.Length != 0) sb.Append(","); sb.Append("DeleteSubdirectoriesAndFiles"); }
            if (CanExecuteFile) { if (sb.Length != 0) sb.Append(","); sb.Append("ExecuteFile"); }
            if (CanFullControl) { if (sb.Length != 0) sb.Append(","); sb.Append("FullControl"); }
            if (CanListDirectory) { if (sb.Length != 0) sb.Append(","); sb.Append("ListDirectory"); }
            if (CanModify) { if (sb.Length != 0) sb.Append(","); sb.Append("Modify"); }
            if (CanRead) { if (sb.Length != 0) sb.Append(","); sb.Append("Read"); }
            if (CanReadAndExecute) { if (sb.Length != 0) sb.Append(","); sb.Append("ReadAndExecute"); }
            if (CanReadAttributes) { if (sb.Length != 0) sb.Append(","); sb.Append("ReadAttributes"); }
            if (CanReadData) { if (sb.Length != 0) sb.Append(","); sb.Append("ReadData"); }
            if (CanReadExtendedAttributes) { if (sb.Length != 0) sb.Append(","); sb.Append("ReadExtendedAttributes"); }
            if (CanReadPermissions) { if (sb.Length != 0) sb.Append(","); sb.Append("ReadPermissions"); }
            if (CanSynchronize) { if (sb.Length != 0) sb.Append(","); sb.Append("Synchronize"); }
            if (CanTakeOwnership) { if (sb.Length != 0) sb.Append(","); sb.Append("TakeOwnership"); }
            if (CanTraverse) { if (sb.Length != 0) sb.Append(","); sb.Append("Traverse"); }
            if (CanWrite) { if (sb.Length != 0) sb.Append(","); sb.Append("Write"); }
            if (CanWriteAttributes) { if (sb.Length != 0) sb.Append(","); sb.Append("WriteAttributes"); }
            if (CanWriteData) { if (sb.Length != 0) sb.Append(","); sb.Append("WriteData"); }
            if (CanWriteExtendedAttributes) { if (sb.Length != 0) sb.Append(","); sb.Append("WriteExtendedAttributes"); }
            if (sb.Length == 0)
                sb.Append("None");
            return sb.ToString();
        }
        /// /// Convenience method to test if the right exists within the given rights
        public static bool Contains(FileSystemRights right, FileSystemAccessRule rule)
        {
            bool returnValue = false;
            if (rule != null)
            {
                returnValue = (((int)right & (int)rule.FileSystemRights) == (int)right);
            }
            return returnValue;
        }
    }
