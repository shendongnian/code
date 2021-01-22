        [XmlRoot("highScore")]
        public class HighScore
        {
            [XmlElement("name")]
            public string Name { get; set; }
            [XmlElement("dateTime")]
            public DateTime Date { get; set; }
            [XmlElement("score")]
            public int Score { get; set; }
        }
        static void Main(string[] args)
        {
            IList<HighScore> highScores = new[] { 
                new HighScore {Name = "bob", Date = DateTime.Now, Score = 10 },
                new HighScore {Name = "john", Date = DateTime.Now, Score = 9 },
                new HighScore {Name = "maria", Date = DateTime.Now, Score = 28 }
            };
            
            // serializing Array
            XmlSerializer s = new XmlSerializer(typeof(HighScore[]));
            using (Stream st = new FileStream(@"c:\test.xml", FileMode.Create))
            {
                s.Serialize(st, highScores.ToArray());
            }
            // deserializing Array
            HighScore[] highScoresArray;
            using (Stream st = new FileStream(@"c:\test.xml", FileMode.Open))
            {
                highScoresArray = (HighScore[])s.Deserialize(st);
            }
            foreach (var highScore in highScoresArray)
            {
                Console.WriteLine("{0}, {1}, {2} ", highScore.Name, highScore.Date, highScore.Score);
            }
        }
