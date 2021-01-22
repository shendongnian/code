    DateTime[] v = new DateTime[]
    {
        new DateTime(2010, 01, 01, 01, 01, 00, 100),
        new DateTime(2010, 01, 01, 01, 01, 30, 200),
        new DateTime(2010, 01, 01, 02, 01, 00, 300),
        new DateTime(2010, 01, 01, 03, 01, 45, 400)
    };
    var x = from t in v
            //group t by t.ToString("yyyy-MM-dd HH:mm") into g
            group t by t.AddSeconds(-t.TimeOfDay.TotalSeconds % 60) into g
            select new { Tag = g.Key, Frequency = g.Count() };
