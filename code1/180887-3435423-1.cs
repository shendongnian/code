    var groups = rows
        .GroupBy(x => new { x.A, x.B, x.C, x.D, x.E, x.F })
        .GroupBy(x => new { x.Key.A, x.Key.B, x.Key.C, x.Key.D, x.Key.E })
        .GroupBy(x => new { x.Key.A, x.Key.B, x.Key.C, x.Key.D, })
        .GroupBy(x => new { x.Key.A, x.Key.B, x.Key.C })
        .GroupBy(x => new { x.Key.A, x.Key.B })
        .GroupBy(x => x.Key.A);
    groups.First().Key;             // will be an A value
    groups.First().First().First(); // will be an A, B, C group
