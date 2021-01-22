    var webClient = new WebClient();
    Debug.Info("PostingForm: " + url);
    try
    {
         byte [] responseArray = webClient.UploadValues(url, nameValueCollection);
         return new Response(responseArray, (int) HttpStatusCode.OK);
    }
    catch (WebException e)
    {
         var response = (HttpWebResponse)e.Response;
         byte[] responseBytes = IOUtil.StreamToBytes(response.GetResponseStream());
         return new Response(responseBytes, (int) response.StatusCode);
    }  
