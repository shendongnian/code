    List<double> list1 = new List<double>() { 1.2, 3.8, double.NaN, 17.8 };
    List<double> list2 = new List<double>() { 9.4, double.PositiveInfinity, 10.4, 26.2 };
    
    var query = from x in list1.Select((item, idx) => new { item, idx })
                where !double.IsNaN(x.item) && !double.IsInfinity(x.item)
                join y in list2.Select((item, idx) => new { item, idx })
                on x.idx equals y.idx
                where !double.IsNaN(y.item) && !double.IsInfinity(y.item)
                select new { X = x.item, Y = y.item };
