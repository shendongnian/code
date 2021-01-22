    var workingCopyClient = new SvnWorkingCopyClient();
    
    SvnWorkingCopyVersion version;
    
    workingCopyClient.GetVersion(workingFolder, out version);
