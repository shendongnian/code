    DataTable Subtraction_result = newDt.AsEnumerable()
                .Join(newDt1.AsEnumerable(), d1 => d1["batch_num"], d2 => d2["batch_num"], (d1, d2) => new { D1 = d1, D2 = d2 })
                .Select(r =>
                {
                    var row = newDt1.NewRow();
                    row["batch_num"] = Convert.ToInt32(r.D1["batch_num"]);
                    row["qty"] = Convert.ToInt32(r.D2["qty"]) - Convert.ToInt32(r.D1["qty"]);
                    return row;
                }).CopyToDataTable();
