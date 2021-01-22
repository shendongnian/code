    var ds = new DirectorySecurity();
    var sid = new SecurityIdentifier(WellKnowSitType.CreatorOwnerSid)
    var ace = new FileSystemAccessRule(sid,
                                       FileSystemAccessRights.FullControl,
                                       AccessControlType.Allow);
    ds.AddAccessRule(ace);
