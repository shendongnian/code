    using (var client = new HttpClient())
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, GlobalConstants.LdapUri + GlobalConstants.FortressAPIUriDev);
        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", userName, password))));
        var response = await client.SendAsync(requestMessage);
    }
