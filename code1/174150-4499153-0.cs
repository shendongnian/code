        // Fix up the DACL on the pipe before opening the listener instance
        // This won't disturb the SACL containing the mandatory integrity label
        NamedPipeServerStream handleForSecurity = null;
        try
        {
            handleForSecurity = new NamedPipeServerStream("NamedPipe/Test", PipeDirection.InOut, -1, PipeTransmissionMode.Byte, PipeOptions.None, 0, 0, null, System.IO.HandleInheritability.None, PipeAccessRights.ChangePermissions);
            PipeSecurity ps = handleForSecurity.GetAccessControl();
            PipeAccessRule aceClients = new PipeAccessRule(
                new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null), // or some other group defining the allowed clients
                PipeAccessRights.ReadWrite, 
                AccessControlType.Allow);
            PipeAccessRule aceOwner = new PipeAccessRule(
                WindowsIdentity.GetCurrent().Owner,
                PipeAccessRights.FullControl,
                AccessControlType.Allow);
            ps.AddAccessRule(aceClients);
            ps.AddAccessRule(aceOwner);
            handleForSecurity.SetAccessControl(ps);
        }
        finally
        {
            if (null != handleForSecurity) handleForSecurity.Close();
            handleForSecurity = null;
        }
