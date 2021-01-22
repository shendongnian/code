    private bool DateGreaterOrEqual(DateTime dt1, DateTime dt2)
            {
                return DateTime.Compare(dt1.Date, dt2.Date) >= 0;
            }
    
    private bool DateLessOrEqual(DateTime dt1, DateTime dt2)
            {
                return DateTime.Compare(dt1.Date, dt2.Date) <= 0;
            }
