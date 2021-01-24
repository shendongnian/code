    private void ProcessJson(string json)
    {
    	var jObject = JsonConvert.DeserializeObject<JObject>(json);
    
    	switch (jObject.Value<string>("eventType"))
    	{
    		case "playerListUpdate":
    			HandlePlayerListUpdate(jObject.ToObject<NetworkMessage<string>>());
    			break;
    		case "latestPlayersList":
    			HandleLatestPlayersList(jObject.ToObject<NetworkMessage<List<Player>>>());
    			break;
    	}
    }
    
    private void HandlePlayerListUpdate(NetworkMessage<string> playerListUpdateMessage)
    {
    	Console.WriteLine($"Player list update: {playerListUpdateMessage.Data}");
    }
    
    private void HandleLatestPlayersList(NetworkMessage<List<Player>> latestPlayersListMessage)
    {
    	Console.WriteLine($"Latest Players list: {latestPlayersListMessage.Data.Count} players");
    }
    
