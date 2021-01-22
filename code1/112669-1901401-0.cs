    string urlToTry = "http://www.example.com/ServerErrorPage.htm";
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlToTry);
    try
    {
      HttpWebResponse response = (HttpWebResponse)request.GetResponse();
      
      // Process your success response.
    }
    catch (WebException we)
    {
      HttpWebResponse error = (HttpWebResponse)we.Response;
      // If you want to log multiple codes, prefer a switch statement.
      if (error.StatusCode == HttpStatusCode.InternalServerError)
      {
        // This is your 500 internal server error, perform logging.
      }
    }
