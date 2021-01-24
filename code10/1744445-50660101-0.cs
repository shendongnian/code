    RestRequest request = new RestRequest("MemberAndChannels/{userId}/{channelId}.json", Method.POST);
    request.AddParameter("auth", accessKey); // or request.AddHeader("auth", accessKey);
    request.AddUrlSegment("userId", user.UUID);
    request.AddUrlSegment("channelId", channel.UUID);
    
    request.AddHeader("Content-Type", "application/json");
    request.AddHeader("Accept", "application/json");
    request.AddParameter("application/json", channelJson, ParameterType.RequestBody);
    
    IRestResponse response = client.Execute(request);
    
    if (response.StatusCode == HttpStatusCode.OK)
    {
    
    } 
    else {
    
    }
