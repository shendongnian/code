    var dates = GetDates(DateTime.Now.AddDays(-10),DateTime.Now);
    
     public IEnumerable<DateTime> GetDates(DateTime StartingDate, DateTime EndingDate)
            {
                while (StartingDate <= EndingDate)
                {
                    yield return StartingDate;
                    StartingDate = StartingDate.AddDays(1);
                }
            } 
