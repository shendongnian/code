    public Dictionary<string, decimal> getRecentPlacementHistory()
    {
        var placementHistoryByMonth = new Dictionary<string, decimal>();
        using (DemoLinqDataContext db = new DemoLinqDataContext())
        {
            DateTime now = DateTime.Now;
            for (int i = 0; i < 6; i++)
            {
                DateTime selectedDate = now.AddMonths(-i);
                Decimal monthTotal = 
                   (from a in db.Accounts
                    where (a.Date_Assigned.Value.Month == selectedDate.Month &&
                           a.Date_Assigned.Value.Year == selectedDate.Month.Year)
                    select a.Amount_Assigned).Sum();
                placementHistoryByMonth.Add(selectedDate.ToString("MMM"),
                                            monthTotal);
            }
            return placementHistoryByMonth;
        }
    }
