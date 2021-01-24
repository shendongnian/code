    try
    {
        WebRequest request = WebRequest.Create("https://discordapp.com/api/invites/obviously-invalid-invite-code");
        request.Method = "GET";
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK) // and possibly other checks in the response contents
        {
            Console.WriteLine("Invite link is valid");
        }
    } 
    catch (WebException wex)
    {
        if (((HttpWebResponse)wex.Response).StatusCode == HttpStatusCode.NotFound)
        {
            Console.WriteLine("Invite link is invalid");
        }
        // You may need to account for other 400/500 statuses
        else throw wex;
    }
