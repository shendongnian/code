    public IEnumerable<string> GetPaymentDates()
    {
       DateTime current = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
    
       for (int i=0;i<4;i++)
       {
          yield return current.ToString("MMMM 1st");
          yield return current.ToString("MMMM 15th");
    
          current = current.AddMonths(1);
       }
    }
