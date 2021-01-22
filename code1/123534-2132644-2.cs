    DateTime minDate = DateTime.MaxValue;
    DateTime maxDate = DateTime.MinValue;
    foreach (var r in arr) 
    {
        if (minDate > r.Date)
        {
            minDate = r.Date;
        }
        if (maxDate < r.Date)
        {
            maxDate = r.Date;
        }
    }
