    class SportMatchBase
    {
    	public string Name { get; set; }
    
    	public override string ToString()
    	{
    		return this.Name;
    	}
    }
    
    class SportEvent : SportMatchBase
    {
    	public DateTime Date { get; set; }
    
    	public override string ToString()
    	{
    		return $"{Name} ({Date.ToShortDateString()})";
    	}
    }
    var array = new SportMatchBase[]
    {
    	new SportMatchBase() { Name = "Sport match" },
    	new SportEvent() { Name = "Sport event", Date = DateTime.Now }
    };
    
    string valueRepresentation = string.Join<SportMatchBase>(", ", array);
