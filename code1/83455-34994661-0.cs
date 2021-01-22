    HttpWebResponse response = null;
    HttpStatusCode statusCode;
    try
    {
        response = (HttpWebResponse)request.GetResponse();
    }
    catch (WebException we)
    {
        response = (HttpWebResponse)we.Response;
    }
    
    statusCode = response.StatusCode;
    Stream dataStream = response.GetResponseStream();
    StreamReader reader = new StreamReader(dataStream);
    sResponse = reader.ReadToEnd();
    Console.WriteLine(sResponse);
    Console.WriteLine("Response Code: " + (int)statusCode + " - " + statusCode.ToString());
