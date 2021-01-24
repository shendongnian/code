	class MainPageViewModel
	{
		[JsonProperty("results")]
		public ObservableCollection<Spell> availableSpells { get; set; } = new ObservableCollection<Spell>();
		
		public MainPageViewModel()
		{
			JsonConvert.PopulateObject(getSpells(), this);
		}
	
