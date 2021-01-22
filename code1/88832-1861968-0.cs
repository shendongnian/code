    public void WriteRevisions(SvnTarget target, SvnRevision from, SvnRevision to)
    {
        using(SvnClient client = new SvnClient())
        {
            SvnFileVersionsArgs ea = new SvnFileVersionsArgs 
                {
                    Start = from,
                    End = to
                };
    
            client.FileVersions(target, ea,
                delegate(object sender2, SvnFileVersionEventArgs e)
                    {
                        Debug.WriteLine(e.Revision);
                        e2.WriteTo(...);
                     });
        }
    }
