    public class RateEntry
    {
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Rate { get; set; }
    }
    class Program
    {
        const string DATE_FORMAT_IN = "yyyy-MM-dd";
        const string DATE_FORMAT_OUT = "yyyy-MM-dd";
        static void Main()
        {
            var inputRateDataRaw = File.ReadAllLines(@"c:\temp\RATES_IN.csv");
            
            DateTime startDate = new DateTime(1997, 05, 31);
            // parse the input dates and rates
            var rateDataFiltered = inputRateDataRaw
                .Select(rateData =>
                {
                    var dataComponents = rateData.Split(',');
                    DateTime rateDate = DateTime.ParseExact(dataComponents[0], DATE_FORMAT_IN, null);
                    decimal rate = decimal.Parse(dataComponents[1]);
                    return new RateEntry() { StartDate = rateDate, Rate = rate };
                })
                .Where(a => a.StartDate > startDate)
                .OrderBy(a => a.StartDate)
                .ToList();            
            List<RateEntry> rateRanges = new List<RateEntry>();
            for (int i = 0; i < rateDataFiltered.Count; i++)
            {
                RateEntry next = ((i + 1) == rateDataFiltered.Count) ? null : rateDataFiltered[i + 1];
                RateEntry last = (i == 0) ? null : rateDataFiltered[i - 1];
                RateEntry now = rateDataFiltered[i];
                // if this is the first rate, or if the last rate isn't this rate, this is a new entry.
                if (last == null || last.Rate != now.Rate)                
                    rateRanges.Add(now); 
                // if the next rate isn't this one, then the current entry expiration is this one's start date.
                if (next == null || next.Rate != now.Rate) 
                    rateRanges.Last().ExpirationDate = now.StartDate; 
            }
                        
            // write the data out
            using (StreamWriter writer = new StreamWriter(@"c:\temp\RATES_OUT.csv"))
            {
                writer.WriteLine("ROWID;STARTDATE;EXPIRATIONDATE;RATE");
                for (int i = 0; i < rateRanges.Count; i++)
                {
                    RateEntry rateEntry = rateRanges[i];
                    writer.WriteLine($"{i};{rateEntry.StartDate.ToString(DATE_FORMAT_OUT)};{rateEntry.ExpirationDate.ToString(DATE_FORMAT_OUT)};{rateEntry.Rate}");
                }
            }
            Console.ReadKey();
        }
    };
