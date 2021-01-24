        DataTable newDt = dt.AsEnumerable()
            .GroupBy(r => r.Field<int>("tid"))
            .Select(g => {
                var row = dt.NewRow();
                row["tid"] = g.Key;
                row["code"] = g.First(r => r["code"] != null).Field<int>("code");
                row["pNameLocal"] = g.First(r => r["pNameLocal"] != null).Field<string>("pNameLocal");
                row["qty"] = g.Sum(r => r.Field<int>("qty"));
                row["price"] = g.Sum(r => r.Field<double>("price"));
                return row;
            }).CopyToDataTable();
