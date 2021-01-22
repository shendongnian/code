        try
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://mysite.com");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();          
        }
        catch(WebException ex)
        {
            HttpWebResponse webResponse = (HttpWebResponse)ex.Response;          
            if (webResponse.StatusCode == HttpStatusCode.NotFound)
            {
                //Handle 404 Error...
            }
        }
