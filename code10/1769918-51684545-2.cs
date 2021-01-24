        class Program
        {
            static void Main(string[] args)
            {
                Conts conts = new Conts();
                List<NpaDatas> data = conts.NpaInfo.NpaDatas
                    .OrderByDescending(x => x.DataMonth)
                    .GroupBy(x => x.DataMonth).Select(x => x.FirstOrDefault()).ToList();
                //To get the second latest use followng
                NPaDatas results = data.Skip(1).FirstOrDefault();
            }
        }
        public class NpaDatas
        {
            public string NpaInfoId { get; set; }
            public DateTime DataMonth { get; set; }
            public PV PartnerPv { get; set; }
            public PV PerformanceBonusLevelId { get; set; }
            public PV GroupPv { get; set; }
        }
        public class PV
        {
            //data not specified 
        }
        public class Conts
        {
            public NpaInfo NpaInfo { get; set; }
        }
        public class NpaInfo
        {
            public string ID { get; set; }
            public List<NpaDatas> NpaDatas { get; set; }
        }
