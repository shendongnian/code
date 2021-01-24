    public class Difficulty
    {
        public int Fractional;
        public int ArtistMax;
        private readonly List<Difficulty> QuestionDifficultyList = new List<Difficulty>();
        public Difficulty()
        {
            PopulateDifficultyData();
        }
        public void PopulateDifficultyData()
        {
                Fractional = 3,
                ArtistMax = 30
         }
    }
