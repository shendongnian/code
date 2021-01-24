    public class Step
    {
        public int StepID { get; set; }
        public string Description { get; set; }
        public List<int> ShutMoves { get; set; }
        public List<int> FeatIDs { get; set; }
        public List<int> ExpSettings { get; set; }
    }
    
    public class Part
    {
        public int PartID { get; set; }
        public string Description { get; set; }
        public bool Moving { get; set; }
        public List<int> FeatIDs { get; set; }
    }
    
    public class Feat
    {
        public int FeatID { get; set; }
        public int CamID { get; set; }
        public int CamFeatID { get; set; }
        public int PartID { get; set; }
    }
    
    public class RootObject
    {
        public List<Step> Steps { get; set; }
        public List<Part> Parts { get; set; }
        public List<Feat> Feats { get; set; }
    }
