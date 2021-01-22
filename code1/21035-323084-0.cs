    class Udr { // formatted for space
        public int BytesIn { get; set; }
        public UdrAnalysis Analysis { get; set; }
        public DateTime StartedDate { get; set; }
    }
    class UdrAnalysis {
        public int Discrepency { get; set; }
        public int DiscrepencyPercent { get; set; }
    }    
    static class Program {
        static void Main() {
            Udr[] data = new [] {
                  new Udr { BytesIn = 50000, StartedDate = DateTime.Today,
                     Analysis = new UdrAnalysis { Discrepency = 50000, DiscrepencyPercent = 130}},
                  new Udr { BytesIn = 500, StartedDate = DateTime.Today,
                     Analysis = new UdrAnalysis { Discrepency = 50000, DiscrepencyPercent = 130}}
            };
            DateTime when = DateTime.Parse("2008-11-10 22:00:44");
            var query = data.AsQueryable().Where(
                @"bytesin > 1000 && (analysis.discrepency > 100000
                    || analysis.discrepencypercent > 100)
                    && starteddate > @0",when)
                .OrderBy("analysis.discrepency DESC")
                .Take(10);
            foreach(var item in query) {
                Console.WriteLine(item.BytesIn);
            }
        }
    }
