    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using SharpSvn;
    ....
    private List<string> GetSVNPaths()
    {
      List<string> files = new List<string>();
      using (SvnClient svnClient = new SvnClient())
      {
        Collection<SvnListEventArgs> contents;
        //you can get the url from the TortoiseSVN repo-browser if you aren't sure
        if (svnClient.GetList(new Uri(@"https://your-repository-url/"), out contents))
        {
          files.AddRange(contents.Select(item => item.Path));
        }
      }
      return files;
    }
