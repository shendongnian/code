    public DateTime GetNextMonday()
    {
    
            DateTime dt = DateTime.Today;
            while (dt.DayOfWeek != DayOfWeek.Monday)
            {
                dt = dt.AddDays(1);
            }
            return dt;
    }
