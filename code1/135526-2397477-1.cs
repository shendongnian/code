    Stream s= null;
    try
    {
        s = clnt.GetRequestStream();
        s.Write(dataBytes, 0, dataBytes.Length);
        s.Close();
        // get the response
        try
        {
            HttpWebResponse resp = (HttpWebResponse) req.GetResponse();
            if (resp == null) return null;
            // expected response is a 200 
            if ((int)(resp.StatusCode) != 200)
                throw new Exception(String.Format("unexpected status code ({0})", resp.StatusCode));
            for(int i=0; i < resp.Headers.Count; ++i)  
                    ;  //whatever
            var MyStreamReader = new System.IO.StreamReader(resp.GetResponseStream());
            string fullResponse = MyStreamReader.ReadToEnd().Trim();
        }
        catch (Exception ex1)
        {
            // handle 404, 503, etc...here
        }
    }    
    catch 
    {
    }
