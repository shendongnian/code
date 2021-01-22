    DateTime startDate = new DateTime(2010, 1, 1);
    DateTime endDate = new DateTime(2010, 12, 31);
    
    int monthCount =
        (endDate.Month - startDate.Month + 1) +
        (endDate.Year - startDate.Year) * 12;
    
    Enumerable
        .Range(0, monthCount)
        .Select(x => new DateTime(startDate.Year, startDate.Month, 1).AddMonths(x))
        .ToList()
        .ForEach(d1 =>
        {
            string month = d1.ToString("MMMM");
            // here should be your code
            // to work with months
    
            Enumerable
                .Range(0, d1.AddMonths(1).AddDays(-1).Day)
                .Select(x => d1.AddDays(x))
                .ToList()
                .ForEach(d2 =>
                {
                    string dayOfWeek = d2.ToString("ddd");
                    string day = d2.Day.ToString();
                    // here should be your code
                    // to work with days
                });
        });
