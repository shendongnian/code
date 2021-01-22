    namespace Sample
    {
        class Timing
        {
            public struct ListMonth
            {
                public readonly int Year;
                public readonly int Month;
                public readonly string Description;
                public readonly DateTime StartDate;
                public readonly DateTime NextStartDate;
                public ListMonth(int year, int month, string description, DateTime startDate, DateTime nextStartDate)
                {
                    Year = year;
                    Month = month;
                    Description = description;
                    StartDate = startDate;
                    NextStartDate = nextStartDate;
                }
                public override string ToString()
                {
                    return Description;
                }
            }
            public List<ListMonth> GetMonthsFromToday(int months)
            {
                List<ListMonth> _return = new List<ListMonth>();
    
                dcTimingDataContext dc = new dcTimingDataContext();
                var data = dc.spGetMonthsFromToday(months);
                foreach (var row in data)
                {
                    ListMonth month = new ListMonth(row.YearNumber.Value, row.MonthNumber.Value, row.MonthDesc, row.MonthStartDate.Value, row.NextMonthStartDate.Value);
                    _return.Add(month);               
                }
                return _return;
            }           
        }
    }
