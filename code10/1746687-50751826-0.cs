    class PlayerData
    {
        public ulong id;
        public string name;
        public int kills;
        public int deaths;
    }
    object getStats(ulong uid, string stat)
    {
        var player = BasePlayer.FindByID(uid);
        PlayerData data = PlayerData.Find(player);
        object value = data.GetType().GetProperty(stat).GetValue(data, null);
        return value;
    }
