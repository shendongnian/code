    Security s = new Security();
            
    DateTime nowDate = DateTime.Now;
    s.ReportPeriods = new List<ReportPeriod>();
    for(int i = 0; i <= 70; i = i + 5)
    {
      s.ReportPeriods.Add(new ReportPeriod(nowDate.AddDays(i), nowDate.AddDays( i + 3), 200 ));
    }
    Dictionary<DateTime, double> AmountGroupedByMonth = s.AmountGroupedByMonth;
