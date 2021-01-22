    public static bool ServiceExists(string url, bool throwExceptions, out string errorMessage)
    {
        try
        {
            errorMessage = string.Empty;
            // try accessing the web service directly via it's URL
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 30000;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception("Error locating web service");
            }
            // try getting the WSDL?
            // asmx lets you put "?wsdl" to make sure the URL is a web service
            // could parse and validate WSDL here
        }
        catch (WebException ex)
        {   
            // decompose 400- codes here if you like
            errorMessage = string.Format("Error testing connection to web service at \"{0}\":\r\n{1}", url, ex);
            Trace.TraceError(errorMessage);
            if (throwExceptions)
                throw new Exception(errorMessage, ex);
        }   
        catch (Exception ex)
        {
            errorMessage = string.Format("Error testing connection to web service at \"{0}\":\r\n{1}", url, ex);
            Trace.TraceError(errorMessage);
           if (throwExceptions)
                throw new Exception(errorMessage, ex);
            return false;
        }
        return true;
    }
