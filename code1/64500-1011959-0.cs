    //loop through each sub site
    for (int i = 0; i <= rootweb.Webs.Count; i++)
    {
      using (SPWeb subweb = rootweb.Webs[i])
      {
        //do stuff
      }
    }
