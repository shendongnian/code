    public Class WorkDay
    {
        public DateTime Date { get; set; }
        public ShiftType ShiftType { get; set; }
        public bool IsOff { get; set;}
        public string HolidayName { get; set; }
        public WorkDay(DateTime date)
        {
              Date = date;
              if (date.DayOfWeek = DayOfWeek.Saturday || date.DayOfWeek = DayOfWeek.Sunday )
              IsOff = true;
        } 
    }
    
    enum ShiftType 
    {
       Morning, Mid , Night
    }
