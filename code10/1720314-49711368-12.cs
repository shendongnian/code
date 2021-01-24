    class MainPageViewModel
	{
        public const string spellUri = "http://dnd5eapi.co/api/Spells";
		public ObservableCollection<Spell> availableSpells { get; set; } // = new ObservableCollection<Spell>();
		
		public MainPageViewModel()
		{
            availableSpells = parseSpellData(spellUri);
		}
		static ObservableCollection<Spell> parseSpellData(string spellUri)
		{
            var parsedSpellData = JsonExtensions.DeserializeAnonymousTypeFromUri(spellUri, new { results = (List<NameAndUri<Spell>>)null });			
			var query = parsedSpellData.results.Select(s => s.Deserialize());
			return new ObservableCollection<Spell>(query);
		}	
	}
