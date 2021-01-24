    FileInfo fInfo = new FileInfo(path);
            if (fInfo.Exists)
            {
                FileSecurity security = fInfo.GetAccessControl();
                security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null), FileSystemRights.ReadAndExecute, AccessControlType.Allow));
                fInfo.SetAccessControl(security);
            }
