    using(SvnClient cl = new SvnClient())
    {
      SvnLogArgs la = new SvnLogArgs();
      Collection<SvnLogEventArgs> col;
      la.Start = 1234;
      la.End = 4567;
      cl.GetLog(new Uri("http://svn.collab.net/repos/svn"), la, out col))
    }
        
