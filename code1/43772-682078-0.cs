    using(SvnClient client = new SvnClient())
    {
        Collection<SvnLogEventArgs> list;
        // When not using cached credentials
        // c.Authentication.DefaultCredentials = new NetworkCredential("user", "pass")l
        SvnLogArgs la = new SvnLogArgs { Start=128; End=132; };
        client.GetLog(new Uri("http://my/repository"), la, out list);
        foreach(SvnLogEventArgs a in list)
        {
           Console.WriteLine(string.Format("=== r{0} : {1} ====", a.Revision, a.Author));
           Console.WriteLine(a.LogMessage)
        }
    }
