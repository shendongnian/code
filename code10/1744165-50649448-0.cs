    public class ActualRainfall
    {
        public List<Rainfallareaavg> RainfallAreaAVG { get; set; }
    }
        public class Rainfallareaavg
        {
            public string AreaBbsID { get; set; }
            public string DistCount { get; set; }
            public string Amount { get; set; }
            public string Hail { get; set; }
            public List<Arealdetail> ArealDetails { get; set; }
        }
        public class Arealdetail
        {
            public string DistBbsID { get; set; }
            public string SubDistCount { get; set; }
            public string Amount { get; set; }
            public string Hail { get; set; }
            public List<Distdetail> DistDetails { get; set; }
        }
        public class Distdetail
        {
            public string SubDistBbsID { get; set; }
            public string Amount { get; set; }
            public string Hail { get; set; }
            public string Date { get; set; }
        }
