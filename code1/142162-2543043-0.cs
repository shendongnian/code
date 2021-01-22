    class Player
	{
		private readonly string _Name;
		private int _KillsCount = 0;
		private int _DeathsCount = 0;
		private bool _IsChanged = false;
		public string Name
		{
			get { return _Name; }
		}
		public int DeathsCount
		{
			get { return _DeathsCount; }
			private set
			{
				if (_DeathsCount != value)
				{
					_DeathsCount = value;
					_IsChanged = true;	
				}	
			}
		}
		public int KillsCount
		{
			get { return _KillsCount; }
			private set
			{
				if (_KillsCount != value)
				{
					_KillsCount = value;
					_IsChanged = true;	
				}
			}
		}
		public bool IsChanged
		{
			get { return _IsChanged; }
			set { _IsChanged = value; }
		}
		public Player(string name)
		{
			_Name = name;
		}
		public void Kill(Player killer)
		{
			DeathsCount++;
			killer.KillsCount++;
		}
	}
	class Example
	{
		private readonly Collection<Player> _Players = new Collection<Player>();
		private bool _IsUpdateEnabled;
		private int _UpdateTimeout = 1000;
		public void Start()
		{
			_Players.Add(new Player("Bob"));
			_Players.Add(new Player("Frank"));
			_Players.Add(new Player("Tom"));
			_IsUpdateEnabled = true;
			new Thread(UpdateThreadMethod).Start();
			// bloody mess here
		}
		private void UpdateThreadMethod()
		{
			while (_IsUpdateEnabled)
			{
				foreach (var player in _Players)
				{
					if (player.IsChanged)
					{
						// update database
						// e.g. "update stats set kills = @kills, deaths = @deaths where name = @name"
						// where
						// @kills is players.KillsCount
						// @deaths is player.DeathsCount
						// @name is player.Name
						player.IsChanged = false;
					}
				}
				
				Thread.Sleep(_UpdateTimeout);
			}	
		}
	}
