    public IEnumerable<DateTime> GetPaymentDates()
    {
       DateTime first = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
       DateTime fifteenth = first.AddDays(14);
       for (int i=0;i<4;i++)
       {
          yield return first;
          yield return fifteenth;
          first = first.AddMonths(1);
          fifteenth = first.AddDays(14);
       }
    }
