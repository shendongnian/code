	public ObservableCollection<Spell> parseSpellData(string listOfSpells)
	{
		var parsedSpellData = JsonConvert.DeserializeAnonymousType(listOfSpells, new { results = (ObservableCollection<Spell>)null });
		return parsedSpellData.results;
	}	
