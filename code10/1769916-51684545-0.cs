        class Program
        {
            static void Main(string[] args)
            {
                Conts conts = new Conts();
                List<NpaData> data = conts.NpaInfo.NpaData.OrderByDescending(x => x.DataMonth)
                    .GroupBy(x => x.DataMonth).Select(x => x.FirstOrDefault()).ToList();
            }
        }
        public class NpaData
        {
            public string PartnerPvPrev { get; set;}
            public string GroupPvPrev { get; set; }
            public string LevelPrev { get; set; }
            public string PartnerPv { get; set; }
            public string Level { get; set; }
            public string GroupPv { get; set; }
            public DateTime DataMonth { get; set; }
        }
        public class Conts
        {
            public NpaInfo NpaInfo { get; set; }
        }
        public class NpaInfo
        {
            public List<NpaData> NpaData { get; set; }
        }
