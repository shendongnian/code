    public static string GetUsernameFromLink(string link)
    {
      if (Uri.IsWellFormedUriString(link, UriKind.Absolute))
      {
        // TODO: Extract
        Uri baseUri = new Uri(link);
        var un = baseUri.Host.Split('.').First();
      }
      return link;
    }
   
 
