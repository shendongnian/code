    using(contextSite = SPControl.GetContextSite(Context))
    {
      using (SPWeb site = siteCollection.OpenWeb("News"))
      {
        //do stuff with your news web
      }
    }
