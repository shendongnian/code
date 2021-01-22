        class UserInfo
        {
            public int Id { get; set; }
            public int UId { get; set; }
            public string Name { get; set; }
        }
        class Score
        {
            public int Id { get; set; }
            public int UId { get; set; }
            public int SScore { get; set; }
        }
        public class ScoreUser
        {
            public int uid { get; set; }
            public string name { get; set; }
            public int score { get; set; }
            public override string ToString()
            {
                return string.Format("UId:{0} Name:{1} Score:{2}", uid, name, score);
            }
        }
        static void Main(string[] args)
        {
            List<UserInfo> infos = new List<UserInfo>()
            {
                new UserInfo {Id = 1, UId = 11, Name = "Billy"},
                new UserInfo {Id = 2, UId = 22, Name = "Paul"},
                new UserInfo {Id = 3, UId = 33, Name = "Joshua"}
            };
            List<Score> scores = new List<Score>()
            {
                new Score {Id = 1, UId = 11, SScore = 30},
                new Score {Id = 2, UId = 22, SScore = 40},
                new Score {Id = 3, UId = 11, SScore = 50},
                new Score {Id = 4, UId = 11, SScore = 60},
                new Score {Id = 5, UId = 33, SScore = 20},
                new Score {Id = 6, UId = 33, SScore = 70},
                new Score {Id = 7, UId = 33, SScore = 80}
            };
            var qry = from s in scores
                      join i in infos on s.UId equals i.UId
                      group s by new { s.UId, i.Name } into g
                      select new ScoreUser
                      {
                          uid = g.Key.UId,
                          name = g.Key.Name,
                          score = g.Max(p => p.SScore)
                      };
            foreach (var su in qry)
            {
                Console.WriteLine(su);
            }
        }
