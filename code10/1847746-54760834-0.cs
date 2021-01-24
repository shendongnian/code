    public class WeeklySalesData
    {
        string weekName;
        DateTime date;
        decimal totalSales;
        // If WeeklySalesData had multiple constructors, you could mark the one to use as follows:
        // [JsonConstructor]
        public WeeklySalesData(string weekName, DateTime date, decimal totalSales)
        {
            this.weekName = weekName;
            this.date = date;
            this.totalSales = totalSales;
        }
        public string WeekName { get { return weekName; } }
        public DateTime Date { get { return date; } }
        public decimal TotalSales { get { return totalSales; } }
    }
