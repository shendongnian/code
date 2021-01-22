    using(SvnClient client = new SvnClient())
    {
       client.Update(@"C:\My\WorkingCopy");
       // Do something to your working copy
       File.AppendAllText(@"C:\My\WorkingCopy", "\nFile Change\n");
       SvnCommitArgs ca = new SvnCommitArgs();
       ca.LogMessage = "Line added";
       client.Commit(@"C:\My\WorkingCopy", ca);
    }
