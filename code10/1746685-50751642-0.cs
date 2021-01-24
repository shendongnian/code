    object TryGetValue(int playerId, string name)
    {
        var player = GetPlayer(playerId);
        switch (name)
        {
            case "name": return name;
            case "kills": return kills;
            // Other properties
            // ...
            default: return null;
        }
    }
