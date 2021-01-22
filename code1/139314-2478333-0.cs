    DaysOfWeek week = DaysOfWeek.Monday | DaysOfWeek.Tuesday;
    
    if ((week & DaysOfWeek.Wednesday) == DaysOfWeek.Wednesday)
    {
        Wednesday.Checked = true;
    }
