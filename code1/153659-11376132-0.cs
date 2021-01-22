    IdentityReference everybodyIdentity = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
    FileSystemAccessRule rule = new FileSystemAccessRule(
        everybodyIdentity,
        FileSystemRights.FullControl, 
        InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
        PropagationFlags.None,
        AccessControlType.Allow);
