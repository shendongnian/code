        public class Sponsor
        {
            public int SponsorLevelId { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return string.Format("Name: {0}", Name);
            }
        }
        public class SponsorLevel
        {
            public int SponsorLevelId { get; set; }
            public string LevelName { get; set; }
        }
        public class SponsorLevelGroup
        {
            public string Level { get; set; }
            public IList<Sponsor> Sponsors { get; set; }
            public override string ToString()
            {
                return string.Format("Level: {0} Sponsors: {1}", Level, Sponsors.Count);
            }
        }
        static void Main(string[] args)
        {
            List<Sponsor> sponsors = new List<Sponsor>()
            {
                new Sponsor { SponsorLevelId = 1, Name = "A" },
                new Sponsor { SponsorLevelId = 2, Name = "B" },
                new Sponsor { SponsorLevelId = 1, Name = "C" },
                new Sponsor { SponsorLevelId = 3, Name = "D" }
            };
            List<SponsorLevel> sponsorLevels = new List<SponsorLevel>()
            {
                new SponsorLevel { SponsorLevelId = 1, LevelName = "L1" },
                new SponsorLevel { SponsorLevelId = 2, LevelName = "L2" },
                new SponsorLevel { SponsorLevelId = 3, LevelName = "L3" }
            };
            var result = (from s in sponsors
                          join sl in sponsorLevels on s.SponsorLevelId equals sl.SponsorLevelId
                          group s by sl.LevelName into g
                          select new SponsorLevelGroup
                          {
                              Level = g.Key,
                              Sponsors = g.ToList()
                          }
             );
            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
         }
