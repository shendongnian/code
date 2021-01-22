    string _localCheckoutPath = @"C:\temp\CheckoutDir\";
    SvnClient client = new SvnClient();
    
    Collection<SvnStatusEventArgs> changedFiles = new Collection<SvnStatusEventArgs>();
    client.GetStatus(_localCheckoutPath, out changedFiles);
    
    //delete files from subversion that are not in filesystem
    //add files to suversion , that are new in filesystem
    
    foreach (SvnStatusEventArgs changedFile in changedFiles)
    {
    	if (changedFile.LocalContentStatus == SvnStatus.Missing)
    	{
    		client.Delete(changedFile.Path);
    	}
    	if (changedFile.LocalContentStatus == SvnStatus.NotVersioned)
    	{
    		client.Add(changedFile.Path);
    	}
    }
    
    SvnCommitArgs ca = new SvnCommitArgs();
    ca.LogMessage = "Some message...";
    
    client.Commit(_localCheckoutPath, ca);
