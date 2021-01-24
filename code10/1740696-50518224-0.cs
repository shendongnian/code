     static void Main(string[] args)
        {
            LeaderboardModel lm = new LeaderboardModel();
            List<LeaderboardModelScoreModels> m = new List<LeaderboardModelScoreModels>();
            lm.ScoreModels = m;
            for (int i= 0;i < 2;i++)
            {
                m.Add(new LeaderboardModelScoreModels() { ScoreModel = new LeaderboardModelScoreModelsScoreModel() { GameSpeed = "hi", Name = "hi", Score = 1 } });
            }
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(LeaderboardModel));
            System.IO.FileStream file = System.IO.File.Open("D:\\a.xml", System.IO.FileMode.Append);
            writer.Serialize(file, lm);
            file.Close();
        }
