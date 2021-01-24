                   dtDetails = dtDetails.AsEnumerable()
                    .GroupBy(r => new { Col1 = r["tid"], Col2 = r["code"], Col3 = r["pNameLocal"] })
                    .Select(g =>
                    {
                        var row1 = dtDetails.NewRow();
                        row1["tid"] = g.Key.Col1;
                        row1["code"] = g.Key.Col2;
                        row1["pNameLocal"] = g.Key.Col3;
                        row1["qty"] = g.Sum(r => r.Field<int>("qty"));
                        row1["price"] = g.Sum(r => r.Field<decimal>("price"));
                        return row1;
                    })
                    .CopyToDataTable();
