    using (SvnClient svnClient = new SvnClient())
    {
        Collection contents;
        List files = new List();
        if (svnClient.GetList(new Uri(svnUrl), out contents))
        {
            foreach(SvnListEventArgs item in contents) 
            {
                files.Add(item.Path);
            }
        }
    }
