    public static string GetFormDigest(HttpClient client)
    {
       var message = new HttpRequestMessage(HttpMethod.Post, "_api/contextinfo");
       message.Headers.Add("Accept", "application/json;odata=verbose");
       var result = client.SendAsync(message).Result;
       result.EnsureSuccessStatusCode();
       var content = result.Content.ReadAsStringAsync().Result;
       var json = JToken.Parse(content);
       var formDigest = json["d"]["GetContextWebInformation"]["FormDigestValue"].ToString();
       return formDigest;
    }
