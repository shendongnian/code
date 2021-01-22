    using(SvnClient client = new SvnClient())
    {
        SvnStatusArgs sa = new SvnStatusArgs();
        sa.Depth = SvnDepth.Empty; // Adjust this to check direct files, or (recursive) directories etc
        Collection<SvnStatusEventArgs> statuses;
        client.GetStatus("c:\\somefile.txt", sa, out statuses); 
        Assert.That(statuses.Count, Is.EqualTo(1));
        Assert.That(SvnStatus.NotVersioned, Is.EqualTo(statuses[0].LocalContentStatus));
    }
