    try
    {
         HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(line);
         myHttpWebRequest.Timeout = 20000;
         myHttpWebRequest.MaximumAutomaticRedirections = 1;
         myHttpWebRequest.AllowAutoRedirect = true;
         HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
         if (myHttpWebResponse.ResponseUri.ToString() == "Some website")
             {
                  //your logic
             }
    
         myHttpWebResponse.Close();
    }
    catch (WebException)
    {
         // record exception
    }
