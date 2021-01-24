    void Main()
	{
		FighterFigure fighterFeature = JsonConvert.DeserializeObject<List<FighterFigure>>(data);
	}
	
	class FighterFigure
	{
		public string Name { get; set; }
		public Feature Feature { get; set; }
	}
	
	class Feature
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
	
	static string data = @"
	[
		{
			'Name': 'Fighting Style (Archery)',
			'Feature': {
				'name': 'Fighting Style (Archery)',
				'Description': 'You gain +2 bonus to attack rolls you make with ranged weapons.'
			},
		},
		{
			'Name': 'Second Wind',
			'Feature': {
				'name': 'Second Wind',
				'Description': 'You have a limited well of stamina that you can draw on to protect Yourself from harm. On your turn, you can use a bonus action to regain hit points equal to ld10 + your fighter leveI.'
			},
		},
		{
			'Name': 'Fighthing Style (Defense)',
			'Feature': {
				'name': 'Fighthing Style (Defense)',
				'Description': 'While you are wearing armor you gain a +1 bonus to AC.'
			},
		}
	]";
