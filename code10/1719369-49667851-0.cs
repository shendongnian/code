    List<DateTime> list = new List<DateTime>();
    DateTime dt = DateTime.Now;
    
    list.Add(dt);
    
    for (int i = 1 ; i < 24; i++)
    {
        list.Add(dt.AddMonths(i));
    }
