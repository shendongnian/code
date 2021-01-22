    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString UrlExpander(string url)
    {
        // Set up the Webrequest
        try
        {
            HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(url);
            try
            {
                // Set autoredirect off so the redirected URL will not be loaded
                wr.AllowAutoRedirect = false;
    
                // Get the response
                HttpWebResponse wresp = (HttpWebResponse)wr.GetResponse();
                wresp.Close();
    
                if (wresp != null)
                    return new SqlString(wresp.Headers["Location"].ToString());
            }
            finally
            {
                if (wr != null)
                    wr.Abort();
            }
        }
        catch
        {
        }
    
        return null;
    
    }
