    while (ub < sentCount)
    {
        ub = step * (1 + (i++));
        var k = (ub > sentCount) ? (sentCount) : ub; //to avoid array out of range exception(assign unitll array length if calc exceeds)
        for (int j = lb; j < k; j++)
        {
            pnos = pnos + "," + pnosList[j].Phone;
        }
        pnos = pnos.Substring(1);
        var postData = new List<KeyValuePair<string, string>>();
        postData.Add(new KeyValuePair<string, string>("authkey", api.AuthenticationKey));
        postData.Add(new KeyValuePair<string, string>("mobiles", pnos));
        postData.Add(new KeyValuePair<string, string>("message", message));
        postData.Add(new KeyValuePair<string, string>("sender", api.SenderId));
        postData.Add(new KeyValuePair<string, string>("route", "default"));
        string sendSMSUri = api.EndPoint;
        using (var httpClient = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Post, sendSMSUri) { Content = new FormUrlEncodedContent(postData) };
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            // do your stuff
        }
        lb = ub;
        pnos = string.Empty;
    }
