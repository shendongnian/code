List<List<object>> players = new List<List<object>>();
    class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    
    void Main()
    {   
        List<object> cricketPlayers = new List<object>();
        cricketPlayers.Add(new Player { ID = 1, Name = "Dhoni" });
        cricketPlayers.Add(new Player { ID = 2, Name = "Kohli" });
        cricketPlayers.Add(new Player { ID = 3, Name = "Gibbs" });
        cricketPlayers.Add(new Player { ID = 4, Name = "Ponting" });
        cricketPlayers.Add(new Player { ID = 5, Name = "Flintoff" });
    
        List<object> footBallPlayers = new List<object>();
        footBallPlayers.Add(new Player { ID = 6, Name = "Ronaldinho" });
        footBallPlayers.Add(new Player { ID = 7, Name = "Messi" });
        footBallPlayers.Add(new Player { ID = 8, Name = "Ronaldo" });
    
        List<object> tennisPlayers = new List<object>();
        tennisPlayers.Add(new Player { ID = 9, Name = "Federer" });
        tennisPlayers.Add(new Player { ID = 10, Name = "Nadal" });
    
        List<List<object>> players = new List<List<object>>();
        players.Add(cricketPlayers);
        players.Add(footBallPlayers);
        players.Add(tennisPlayers);
    
        players.SelectMany(x=>x).ToList().Dump();
    }
