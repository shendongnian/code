    void Main()
    {
    	var seasons = new List<Season>
    	{
    		new Season("Winter", Date1, Date2),
    		new Season("Summer", Date3, Date4)
    	};
    
    	var today = DateTime.Today;
    	
    	// null if no matching season was found
    	var currentSeason = seasons.FirstOrDefault(season => season.InSeason(today))?.Name;
    }
    
    public class Season
    {
    	public Season(string name, DateTime start, DateTime end)
    	{
    		Name = name;
    		Start = start;
    		End = end;
    	}
    	
    	public string Name { get; set; }
    	
    	public DateTime Start { get; set; }
    	public DateTime End { get; set; }
    	
    	public bool InSeason(DateTime input)
    	{
    		return input >= Start && input <= End;
    	}
    }
