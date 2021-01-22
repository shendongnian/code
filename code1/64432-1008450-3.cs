    IEnumerable<string> csvLines = query
        .Select
        (
            x => x.Aggregate
            (
                new { Count = 0, SB = new StringBuilder() },
                (a, y) => new
                {
                    Count = a.Count + 1,
                    SB = ((a.SB.Length == 0) ? a.SB.Append(y.PO) : a.SB)
                        .Append(", ").Append(y.Sku).Append(", ").Append(y.Qty)
                },
                a => a.SB.ToString() + string.Join(", , ", new string[6 - a.Count])
            )
        );
    string csv = string.Join(Environment.NewLine, csvLines.ToArray());
