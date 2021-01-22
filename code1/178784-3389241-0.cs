        static void Main(string[] args)
        {
            List<DateTime> dates = new List<DateTime>();
            dates.Add(new DateTime(2010, 01, 27));
            dates.Add(new DateTime(2010, 01, 30));
            dates.Add(new DateTime(2010, 01, 31));
            dates.Add(new DateTime(2010, 02, 01));
            DateTime startDate = new DateTime(2010, 01, 25);
            DateTime endDate = new DateTime(2010, 02, 02);
            List<DateTime> missingDates = new List<DateTime>(GetMissingDates(dates, startDate, endDate));
           
        }
        private static IEnumerable<DateTime> GetMissingDates(IList<DateTime> dates, DateTime startDate, DateTime endDate)
        {
            TimeSpan _timeStamp = endDate - startDate;
            DateTime _tempDateTime = startDate;
            IList<DateTime> _dateTimeRange = new List<DateTime>();
            IList<DateTime> _missingDates = new List<DateTime>();
            for (int i = 0; i <= _timeStamp.Days; i++)
            {
                _dateTimeRange.Add(_tempDateTime);
                _tempDateTime = _tempDateTime.AddDays(1);
            }
            foreach (DateTime dt in _dateTimeRange)
            {
                if (!dates.Contains(dt))
                    yield return dt;
            }
        }
