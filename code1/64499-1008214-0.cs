    foreach (SPSite site in this.WebApplication.Sites)
    {
      try
      {
        ...
      }
      finally
      {
        site.Dispose();
      }
    }
