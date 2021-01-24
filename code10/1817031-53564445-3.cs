        public class Stats
        {
            public int AvatarAdd { get; set; }
            public int TotalPlays { get; set; }
            public int GameTotalPlaysSpellMemWords { get; set; }
            public int BookTotalReadsCount { get; set; }
            public int GameTotalPlaysCount { get; set; }
            public int CharacterTotalPlaysL { get; set; }
            public int CharacterTotalPlaysE { get; set; }
            public int TotalPlaysPick_Vocab { get; set; }
            public int CharacterTotalPlaysR { get; set; }
        }
    
        public class MyModel
        {
            public int Id { get; set; }
            public int Grade { get; set; }
            public Stats Statistics { get; set; }
        }
