    string wcPath = "c:\\my working copy";
    SvnCommitArgs a = new SvnCommitArgs();
    a.LogMessage = "My log message";
    using (SvnClient client = new SvnClient())
    {
        client.Commit(wcPath, a);
    }
    
