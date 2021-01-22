    static void Main(string[] args)
    {
      SvnHookArguments ha;
      if (!SvnHookArguments.ParseHookArguments(args, SvnHookType.PostCommit, false, out ha))
      {
        Console.Error.WriteLine("Invalid arguments");
        Environment.Exit(1);
      }
 
      using (SvnLookClient cl = new SvnLookClient())
      {
        SvnChangeInfoEventArgs ci;
        cl.GetChangeInfo(ha.LookOrigin, out ci);
        // ci contains information on the commit e.g.
        Console.WriteLine(ci.LogMessage); // Has log message
        
        foreach(SvnChangeItem i in ci.ChangedPaths)
        {
           //
        }
      }
    }
