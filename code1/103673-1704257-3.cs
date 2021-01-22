    var totals = list.Aggregate(
        new { Weight = 0, Length = 0, Items = 0},
        (t, pd) => new { 
            Weight = t.Weight + pd.GrossWeight,
            Length = t.Length + pd.Length,
            Items = t.Items + pd.NrDistaff
        }
    );
