    class Program
    {
        static void Main()
        {
            Team[] teams = LoadTeams("teams.txt");
    
            /* OrderBy uses Player.CompareTo to "randomize" an order */
            Player[] players = LoadPlayers("players.txt").OrderBy(p => p).ToArray();
                        
            for (int i = 0; i < players.Length; i++)
            {
                teams[i % teams.Length].Players.Add(players[i]);
            }
    
            foreach (Team t in teams)
            {
                System.Diagnostics.Debug.WriteLine(t);
            }
        }
    
        static Team[] LoadTeams(string path)
        {
            /* I'm assuming one team per line */
            string[] list = File.ReadAllLines(path);
    
            return list.Select(s => new Team(s)).ToArray();
        }
    
        static Player[] LoadPlayers(string path)
        {
            /* I'm assuming one player per line */
            string[] list = File.ReadAllLines(path);
    
            return list.Select(s => new Player(s)).ToArray();
        }
    }
    
    class Team
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }
    
        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
        }
    
        public override string ToString()
        {
            /* Team name plus the players sorted alphabetically */
            return string.Format("{0}\n{1}", 
                Name, 
                string.Join("\n", 
                            Players.Select(p => string.Concat("\t", p.ToString()))
                                   .OrderBy(s => s)));
        }
    }
    
    class Player : IComparable<Player>
    {
        public string Name { get; set; }
        Guid id = Guid.NewGuid();   //this becomes a "random" draft position
    
        public Player(string name)
        {
            Name = name;
        }
    
        public override string ToString()
        {
            return Name;
        }
    
        #region IComparable<Player> Members
        
        //this basically sets the draft order
        public int CompareTo(Player other)
        {
            return id.CompareTo(other.id);
        }
    
        #endregion
    }
