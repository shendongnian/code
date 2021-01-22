    private SiteMapNode ResolveCustomNodes(object sender, SiteMapResolveEventArgs e)
    {
        string path = e.Context.Request.AppRelativeCurrentExecutionFilePath;
        foreach (var candidate in from node in FindNodesWithQueryString(
                                                                  SiteMap.RootNode)
                                  select new {
                                      Url = node.Url,
                                      UrlNoQuery = node.Url.Split('?')[0],
                                      QueryStringField = x.Node["queryStringField"],
                                      Node = node
                                  } into x
                                  where path.Equals(x.UrlNoQuery, 
                                                 StringComparison.OrdinalIgnoreCase)
                                  select x)
        {
            string paramValue = context.Request.QueryString[
                                                        candidate.QueryStringField];
            
            if (paramValue != null)
            {
                string url = candidate.UrlNoQuery + "?" + candidate.QueryStringField
                           + "=" + HttpUtility.UrlEncode(paramValue);
                if (url.Equals(candidate.Url, StringComparison.OrdinalIgnoreCase))
                    return candidate.Node;
            }   
        }
        return null;
    }
    
