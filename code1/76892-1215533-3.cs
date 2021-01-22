    for (int i = 0; i < ops1; i++)
    {
        Uri myUri = new Uri(site);
        WebRequest myWebRequest = WebRequest.Create(myUri);
        //myWebRequest.Timeout = 200;
        using (WebResponse myWebResponse = myWebRequest.GetResponse())
        {
            // Do what you want with the response.
        } // Your response will be disposed of here
    }
