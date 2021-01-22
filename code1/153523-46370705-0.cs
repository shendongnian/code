    public class DateRange
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
    [TestClass]
    public class DateRangerTest
    {
        private List<DateRange> GetDateRanges(List<DateTime> dates)
        {
            if (dates == null || !dates.Any()) return null;
            dates = dates.OrderBy(x => x.Date).ToList();
            var dateRangeList = new List<DateRange>();
            DateRange dateRange = null;
            for (var i = 0; i < dates.Count; i++)
            {
                if (dateRange == null)
                {
                    dateRange = new DateRange { Start = dates[i] };
                }
                if (i == dates.Count - 1 || dates[i].Date.AddDays(1) != dates[i + 1].Date)
                {
                    dateRange.End = dates[i].Date;
                    dateRangeList.Add(dateRange);
                    dateRange = null;
                }
            }
            return dateRangeList;
        }
        [TestMethod]
        public void GetDateRanges_MultiDateRangeTest()
        {
            var dates = new List<DateTime>
            {
                new DateTime(1999,5,1),
                new DateTime(1999,5,5),
                new DateTime(1999,5,6),
                new DateTime(1999,5,15),
                new DateTime(1999,5,7),
                new DateTime(1999,5,8),
                new DateTime(1999,5,19),
                new DateTime(1999,5,20),
                new DateTime(1999,5,23)
            };
            var dateRanges = GetDateRanges(dates);
            Assert.AreEqual(new DateTime(1999, 5, 1), dateRanges[0].Start);
            Assert.AreEqual(new DateTime(1999, 5, 1), dateRanges[0].End);
            Assert.AreEqual(new DateTime(1999, 5, 5), dateRanges[1].Start);
            Assert.AreEqual(new DateTime(1999, 5, 8), dateRanges[1].End);
            Assert.AreEqual(new DateTime(1999, 5, 15), dateRanges[2].Start);
            Assert.AreEqual(new DateTime(1999, 5, 15), dateRanges[2].End);
            Assert.AreEqual(new DateTime(1999, 5, 19), dateRanges[3].Start);
            Assert.AreEqual(new DateTime(1999, 5, 20), dateRanges[3].End);
            Assert.AreEqual(new DateTime(1999, 5, 23), dateRanges[4].Start);
            Assert.AreEqual(new DateTime(1999, 5, 23), dateRanges[4].End);
        }
    }
