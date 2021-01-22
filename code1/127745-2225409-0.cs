    DateTime[] v = new DateTime[]
    {
        new DateTime(2010, 01, 01, 01, 01, 00),
        new DateTime(2010, 01, 01, 01, 01, 30),
        new DateTime(2010, 01, 01, 02, 01, 00),
        new DateTime(2010, 01, 01, 03, 01, 45)
    };
    var x = from t in v
            group t by t.ToString("yyyy-MM-dd HH:mm") into g
            select new { Tag = g.Key, Frequency = g.Count() };
