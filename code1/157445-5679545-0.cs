    using (SvnClient svnClient = new SvnClient())
    {
       Collection<SvnListEventArgs> contents;
       List<string> files = new List<string>();
       if (svnClient.GetList(new Uri(svnUrl), out contents))
       {
          foreach(SvnListEventArgs item in contents)
          {
             files.Add(item.Path);
          }
       }
    }
