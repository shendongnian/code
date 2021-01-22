    public class RankingListForDisplay 
    {
        public List<RankingListLine> Lines { get; set; }
        public string Period { get; set; }
        public RankingListForDisplay()
        {
            Lines = new List<RankingListLine>();
            Period = "<Unspecified>";
        }
    }
