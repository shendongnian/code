    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataBase db = new DataBase();
                var sportQuery = db.sports.Select(s=> s.leagues.Select(l => l.teams.Select(t => t.players.Select(p => new {
                            playerid =  p.id,
                            playerName = p.name,
                            playerAge = p.age,
                            teamId = t.id,
                            teamName = t.name,
                            teamSucessrate = t.successrate,
                            leagueId= l.id,
                            leagueName= l.name,
                            leagueDescription = l.description,
                            sportId = s.id,
                            sportName = s.name
                }))
                .SelectMany(p => p))
                .SelectMany(t => t))
                .SelectMany(l => l)
                .ToList();
            }
        }
        public class DataBase
        {
            public List<Sports> sports { get; set;}
        }
        public class Sports
        {
            public int id { get; set; }
            public string name { get; set; }
            public List<League> leagues { get; set; }
        }
        public class League
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public List<Team> teams { get; set; }
        }
        public class Team
        {
            public int id { get; set; }
            public string name { get; set; }
            public string successrate { get; set; }
            public List<Player> players { get; set; }
        }
        public class Player
        {
            public int id { get; set; }
            public string name { get; set; }
            public int age { get; set; }
        }
    }
