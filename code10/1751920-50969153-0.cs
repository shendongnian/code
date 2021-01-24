    enum Sport
    {
    	Cricket,
    	Fooball,
    	Tennis
    }
    
    class Player
    {
    	public int ID { get; set; }
    	public string Name { get; set; }
    	public Sport Sport { get; set; }
    }
    
    void Main()
    {
    	List<Player> players = new List<Player>();
    	
    	players.Add(new Player { ID = 1, Name = "Dhoni", Sport = Sport.Cricket });
    	players.Add(new Player { ID = 2, Name = "Kohli", Sport = Sport.Cricket });
    	players.Add(new Player { ID = 3, Name = "Gibbs", Sport = Sport.Cricket });
    	players.Add(new Player { ID = 4, Name = "Ponting", Sport = Sport.Cricket });
    	players.Add(new Player { ID = 5, Name = "Flintoff", Sport = Sport.Cricket });
    
    	players.Add(new Player { ID = 6, Name = "Ronaldinho", Sport = Sport.Fooball });
    	players.Add(new Player { ID = 7, Name = "Messi", Sport = Sport.Fooball });
    	players.Add(new Player { ID = 8, Name = "Ronaldo", Sport = Sport.Fooball });
    
    	players.Add(new Player { ID = 9, Name = "Federer", Sport = Sport.Tennis });
    	players.Add(new Player { ID = 10, Name = "Nadal", Sport = Sport.Tennis });
    
    	players.Select(p => p.Name).Dump();
    	players.Where(p => p.Sport == Sport.Fooball).Select(p => p.Name).Dump();
    }
