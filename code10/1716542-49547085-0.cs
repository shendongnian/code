	class GameInfo
	{
		public Dictionary<string, int> MonsterCards { get; private set; }
		public GameInfo()
		{
			this.MonsterCards = new Dictionary<string, int>()
			{
				{ "Bob", 500 }, { "Billy", 600 }, { "Joe", 700 }, { "Frank", 750 }, { "BillyBob", 850 }
			};
		}
	}
	
	class Battle
	{
		private Random _random = new Random();
		public bool Big { get; private set; }
		public void BigChance()
		{
			this.Big = _random.NextDouble() >= 0.95;
		}
	
		public void BattleStart()
		{
			this.BigChance();
			GameInfo gameInfo = new GameInfo();
			int monster = _random.Next(0, (gameInfo.MonsterCards.Count) / 2);
		}
	}
