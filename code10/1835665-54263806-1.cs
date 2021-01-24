    pubic string ConstructDays(DaysDetails d)
    {
     int Idx = 0;
        string days = "";
        var obj = new DaysDetails ();
        foreach (var p in obj .GetType().GetProperties())
        {   days += (bool)p.GetValue(obj ) ? (days=="" ? Idx.ToString() : ","+Idx.ToString()) : "";
            Idx++;
        }
    return days
    }
