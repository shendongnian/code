    tableA.Join(tableB, e => e.Id, e => e.TableAId, (a, b) => new {
        IsPrevFee = a.ToDt < b.FromDt,
        AEntry = a,
        BEntry = b
    }).Where(e => e.IsPrevFee);
