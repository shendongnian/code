    class Program
    {
        static void Main()
        {
            /* Assuming one team per line */
            Team[] teams = File.ReadAllLines("teams.txt")
                                .Select(t => new Team(t))
                                .ToArray();
    
            /* Assuming one player per line */
            /* new Guid() yields a sufficiently random order */
            string[] players = File.ReadAllLines("players.txt")
                                    .OrderBy(p => new Guid())
                                    .ToArray();
    
            /* 
             * No use randomizing anymore.  
             * Just assign (PlayerCount / TeamCount) players to each team 
             */
            for (int i = 0; i < teams.Length; i++)
            {
                var p = players.Skip(i * players.Length / teams.Length)
                                .Take(players.Length / teams.Length);
    
                teams[i % teams.Length].Players.AddRange(p);
            }
    
            foreach (Team t in teams)
            {
                System.Diagnostics.Debug.WriteLine(t);
            }
        }
    }
    
    class Team
    {
        public string Name { get; set; }
        public List<string> Players { get; set; }
    
        public Team(string name)
        {
            Name = name;
            Players = new List<string>();
        }
    
        public override string ToString()
        {
            /* Team name plus the players sorted alphabetically */
            return string.Format("{0}  \n{1}", 
                Name, 
                string.Join("  \n", 
                            Players.Select(p => string.Concat("\t", p))
                                   .OrderBy(s => s)));
        }
    }
