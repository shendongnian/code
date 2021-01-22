    HttpWebResponse response = null;
    var request = (HttpWebRequest)WebRequest.Create(/* url */);
    request.Method = "HEAD";
	
    try
    {
        response = (HttpWebResponse)request.GetResponse();
    }
    catch (WebException ex)
    {
        /* A WebException will be thrown if the status of the response is not `200 OK` */
    }
    finally
    {
        // Don't forget to close your response.
        if (response != null)
        {
            response.Close()
        }
    }
