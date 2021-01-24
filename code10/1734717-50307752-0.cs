    [Route("users/VerifyLoginCredentials")]
    public IHttpActionResult VerifyLoginCredentials(string username, string password)
     var value = new Dictionary<string, string>
     {
        { "username", "yourUsername" },
        { "passwird", "test123" }
     };
     var content = new FormUrlEncodedContent(value);
     var result = await client.PostAsync("users/verifyLoginCredentials/", content);
     string resultContent = await result.Content.ReadAsStringAsync();
