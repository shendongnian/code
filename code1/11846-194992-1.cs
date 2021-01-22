    Func<DateTime> RandomDayFunc()
    {
        DateTime start = new DateTime(1995, 1, 1); 
        Random gen = new Random(); 
        int range = ((TimeSpan)(DateTime.Today - start)).Days; 
        return () => start.AddDays(gen.Next(range));
    }
