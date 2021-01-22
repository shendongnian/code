    public class Murder
        {
            public DateTime Time { get; set;}
            public Player Killer { get; set; }
            public Player Killed { get; set;}
            public Murder(DateTime time, Player killer, Player killed)
            {
                Time = time;
                Killer = killer;
                Killed = killed;
            }
        }
     
    public class Player
    {
        public int DeathNumber{ get; set;}
        public int KillNumber { get; set; }
    }
    public static class MainClass
    {
        static Dictionary<DateTime, Murder> murders = new Dictionary<DateTime, Murder>();
        
        //Add new murder. Save it to murders and refresh Player statistics.
        public static void AddMurder(Player killer, Player killed)
        {
            DateTime now = DateTime.Now;
            murders.Add(now, new Murder(now, killer, killed));
            killer.KillNumber++;
            killed.DeathNumber++;
        }
        
        public static void GameProcessExample()
        {
            AddMurder(new Player(), new Player());
            Thread.Sleep(1000);
            AddMurder(new Player(), new Player());
            
            //You can use LINQ to select any murders you need: by date or just some number of the last murders.
            var q = from murder in murders
                    where murder.Key > DateTime.Now.AddHours(-1)
                    select murder;
        }
    }
