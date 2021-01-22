        private DirectorySecurity GetDirectorySecurity(string owner)
        {
            const string LOG_SOURCE = "GetDirectorySecurity";
            DirectorySecurity ds = new DirectorySecurity();
            System.Security.Principal.NTAccount ownerAccount =
                new System.Security.Principal.NTAccount(owner);
            ds.SetOwner(ownerAccount);
            ds.AddAccessRule(
                new FileSystemAccessRule(owner,
                FileSystemRights.FullControl,
                InheritanceFlags.ObjectInherit, 
                PropagationFlags.InheritOnly,
                AccessControlType.Allow));
            //AdminUsers is a List<string> that contains a list from configuration
            //  That represents the admins who should be allowed
            foreach (string adminUser in AdminUsers)
            {
                ds.AddAccessRule(
                    new FileSystemAccessRule(adminUser,
                    FileSystemRights.FullControl,
                    InheritanceFlags.ObjectInherit,
                    PropagationFlags.InheritOnly,
                    AccessControlType.Allow));
            }
            return ds;
        }
