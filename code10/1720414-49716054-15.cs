    private static void PrintDateList(DateTime StartDate, DateTime EndDate)
    {
            List<Tuple<DateTime>> EventsDatesRangeList = new List<Tuple<DateTime>>();
            Console.WriteLine("");
            int TotalMonths = EndDate.Month - StartDate.Month +
                            (EndDate.Year - StartDate.Year) * 12;
            int CurrentYear = StartDate.Year;
            for (int i = 0; i <= TotalMonths; i++)
            {
                int CurrentMonth = StartDate.Month + i;
                if (StartDate.Month + i > 12)
                {
                    int MonthsInPreviousYears = (int)Math.Floor((decimal)((StartDate.Month + i) / 12)) * 12;
                    CurrentMonth = StartDate.Month + i - MonthsInPreviousYears;
                    if (CurrentMonth == 0)
                        continue;
                    if ((StartDate.Month + i) % 12 == 1)
                    {
                        CurrentYear++;
                    }
                }
                DateTime FirstDay = new DateTime(CurrentYear, CurrentMonth, 1);
                if (i == 0)
                {
                    FirstDay = StartDate;
                }
                DateTime LastDay = new DateTime(CurrentYear, CurrentMonth, DateTime.DaysInMonth(CurrentYear, FirstDay.Month));
                if (i == TotalMonths)
                {
                    LastDay = EndDate;
                }
                    Console.WriteLine(FirstDay.ToString("d-MMMM") + " to " + LastDay.ToString("d-MMMM"));
                EventsDatesRangeList.Add(new Tuple<DateTime>(FirstDay));
                EventsDatesRangeList.Add(new Tuple<DateTime>(LastDay));
            }
        }
