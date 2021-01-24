    public class Scenario
    {
        public string ScenarioName { get; set; } = "";
        public string ScenarioDescription { get; set; } = "";
        public string ScenarioFile { get; set; } = "";
        public int NumTurns { get; set; } = 0;
....
        [IgnoreDataMember]
        public bool[,] ValidTerrain = new bool[,]
