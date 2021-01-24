    public void SavePlayerInfo(int stageNum, List<Player> playerList)
	{
		Dictionary<int, PlayerInfo> playerInfoTable = new Dictionary<int, PlayerInfo>();
		foreach(Player player in playerList)
		{
			playerInfoTable.Add( player.PId, player.GetPlayerInfoToBeStored());
			StoredPlayerState.Add(stageNum, playerInfoTable);
		}
	}
