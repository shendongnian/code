            // Get a FileSecurity object that represents the
            // current security settings.
            FileSecurity fSecurity = File.GetAccessControl(localFileName);
            // Add the FileSystemAccessRule to the security settings.
            fSecurity.AddAccessRule(new FileSystemAccessRule("DOMAIN\USERNAME",
                FileSystemRights.ReadData, AccessControlType.Allow));
            // Set the new access settings.
            File.SetAccessControl(localFileName, fSecurity);
