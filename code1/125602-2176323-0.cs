    class PeriodOfTime { 
       public DateTime StartTime {get; set;}
       public DateTime EndTime {get; set;}
       public string Description {get; set;} 
    }
    // ... 
    List<PeriodOfTime> periods = new List<PeriodOfTime>();
    var timeToQuery = DateTime.Now.TimeOfDay;
    var period = periods.FirstOrDefault(p => timeToQuery >= p.StartTime &&
                                             timeToQuery <= p.EndTime);
