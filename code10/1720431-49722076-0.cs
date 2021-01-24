    var queryDGroupDT = dataTable.AsEnumerable()
        .GroupBy(c => new { Col3 = c["Column3"], Col4 = c["Column4"] },
                 x => x,
                (k, g) => new
                {
                     Col1Sum = g.Sum(t => t.Field<int>("Column1")),
                     Col2Count = g.Select(t => t.Field<int>("Column2")).Distinct().Count()
                }).FirstOrDefault();
