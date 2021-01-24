    static void Main(string[] args)
    {
        PrintDateList(new DateTime(2018, 2, 12), new DateTime(2018, 5, 23));
        PrintDateList(new DateTime(2018, 11, 12), new DateTime(2019, 2, 23));
        Console.ReadLine();
    }
    private static void PrintDateList(DateTime StartDate, DateTime EndDate)
    {
        Console.WriteLine("");
        int TotalMonths = EndDate.Month - StartDate.Month +
                         (EndDate.Year - StartDate.Year) * 12;
        int CurrentYear = StartDate.Year;
        int MonthsToSubtract = 0;
        for (int i = 0; i <= TotalMonths; i++)
        {
            int CurrentMonth = StartDate.Month + i;
            if (StartDate.Month + i > 12)
            {
                if ((StartDate.Month + i) % 12 == 1)
                {
                    CurrentYear++;
                    Console.WriteLine(CurrentYear.ToString());
                    MonthsToSubtract = StartDate.Month + i - 1;
                }
                CurrentMonth = StartDate.Month + i - MonthsToSubtract;
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
        }
    }
