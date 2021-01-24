    var query =
        from r in dt.AsEnumerable()
        group new
        {
            Column1 = r.Field<int>("Column1"),
            Column2 = r.Field<int>("Column2"),
        }
        by new
        {
            Column3 = r.Field<string>("Column3"),
            Column4 = r.Field<string>("Column4"),
        }
        into g
        select new
        {
            Column1 = g.Select(x => x.Column1).Distinct().Count(), // project first
            Column2 = g.Sum(x => x.Column2),
            g.Key.Column3,
            g.Key.Column4,
            StoreCode = "",
        };
