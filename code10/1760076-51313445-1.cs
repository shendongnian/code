    public class RateEntry
    {
        public DateTime Date { get; set; }
        public decimal Rate { get; set; }
    }
    class Program
    {
        static void Main()
        {
            var fedFundDataRaw = File.ReadAllLines(@"c:\temp\FEDFUNDS_IN.csv");
            string dateFormatIn = "yyyy-MM-dd";
            string dateFormatOut = "yyyy-MM-dd";
            DateTime startDate = new DateTime(1997, 05, 31);
            // parse the input dates and rates
            var fedFundData = fedFundDataRaw.Select(rateData =>
            {
                var dataComponents = rateData.Split(',');
                DateTime rateDate = DateTime.ParseExact(dataComponents[0], dateFormatIn, null);
                decimal rate = decimal.Parse(dataComponents[1]);
                return new RateEntry() { Date = rateDate, Rate = rate };
            });
            decimal? lastSeenRate = null;
            var selectedRateData = fedFundData
                .Where(a => a.Date > startDate) // skip anything that is older than our cut-off date
                .OrderBy(a => a.Date) // order by date
                .Where((rateEntry) =>
                {
                    if (lastSeenRate != null && rateEntry.Rate == lastSeenRate.Value)
                        return false; // we're not interested in this entry if this date has the same as the one we've just seen
                    lastSeenRate = rateEntry.Rate; // set this rate as the last rate we've seen
                    return true;
                })
                .ToList();
            // write the data out
            using (StreamWriter writer = new StreamWriter(@"c:\temp\FEDFUNDS_OUT.csv"))
            {
                writer.WriteLine("ROWID;STARTDATE;EXPIRATIONDATE;RATE");
                for (int i = 0; i < selectedRateData.Count; i++)
                {
                    RateEntry rateEntry = selectedRateData[i];
                    RateEntry nextEntry = ((i + 1) == selectedRateData.Count) ? null : selectedRateData[i + 1];
                    writer.WriteLine($"{i};{rateEntry.Date.ToString(dateFormatOut)};{nextEntry?.Date.ToString(dateFormatOut)};{rateEntry.Rate}");
                }
            }
            Console.ReadKey();
        }
    };
