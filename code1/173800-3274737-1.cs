    Uri siteUri = new Uri("http://www.contoso.com/");
    WebRequest wr = WebRequest.Create(siteUri);
    // now, request the URL from the server, to check it is valid and works
    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse ())
    {
        if (response.StatusCode == HttpStatusCode.OK)
        {
            // if the code execution gets here, the URL is valid and is up/works
        }
        response.Close();
    }
