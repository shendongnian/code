    SPWebService contentService = SPWebService.ContentService;
    foreach(SPWebApplication app in contentService.WebApplications) 
    {
      if (app.Sites.Count > 0) 
      {
    
        // pick the first site (root site)
        SPSite rootSite = app.Sites[0];
        
        Trace.WriteLine(site.Url);
      }
    }
