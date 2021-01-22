    var ds = new DirectorySecurity();
    var sid = new SecurityIdentifier(WellKnowSitType.CreatorOwnerSid, null)
    var ace = new FileSystemAccessRule(sid,
                                       FileSystemAccessRights.FullControl,
                                       AccessControlType.Allow);
    ds.AddAccessRule(ace);
