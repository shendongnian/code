    using (System.Net.WebClient cli = new System.Net.WebClient())
    {
      ......
        //set credentials
        cli.Credentials = Credentials;
        //set headers
        cli.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
        //make a sync call
        response = cli.UploadString(sRemoteUrl, "POST", sJsonRequest);
        ......
    }
