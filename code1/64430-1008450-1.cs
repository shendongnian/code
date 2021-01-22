    var query = yourData
        .GroupBy
        (
            x => x.PO
        )
        .SelectMany
        (
            x => x.Select
            (
                (y, i) => new { y.PO, y.Sku, y.Qty, Key = i / 5 }
            )
        )
        .GroupBy
        (
            x => new { x.PO, x.Key }
        );
    IEnumerable<string> csvLines = query
        .Select
        (
            x => x.Aggregate
            (
                new { Count = 0, SB = new StringBuilder() },
                (a, y) => new
                {
                    Count = a.Count + 2,
                    SB = ((a.SB.Length > 0) ? a.SB : a.SB.Append(y.PO))
                        .Append(", ").Append(y.Sku).Append(", ").Append(y.Qty)
                },
                a => a.SB.ToString() + string.Join(", ", new string[11 - a.Count])
            )
        );
    string csv = string.Join(Environment.NewLine, csvLines.ToArray());
