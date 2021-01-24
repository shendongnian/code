	public async Task<Tuple<UserInventory, UserHeroSet>> LoadAsync(
		Request<ServerUserInventory, UserHeroSet> request)
	{ ... }
	public async Task<Tuple<UserInventory, BattleData>> LoadAsync(
		Request<UserInventory, BattleData> request)
	{ ... }
