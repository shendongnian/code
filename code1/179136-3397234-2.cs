            DataTable sumDataTable = new DataTable();
            sumDataTable.Columns.Add("total", typeof(string));
            sumDataTable.Columns.Add("workedhours", typeof(int));
            sumDataTable.Columns.Add("tfshours", typeof(int));
            
            DataRow row = sumDataTable.NewRow();
            row["total"] = "Total";
            row["workedhours"] = oldDataTable.Compute("Sum(workedhours)", "workedhours > 0");
            row["tfshours"] = oldDataTable.Compute("Sum(tfshours)", "tfshours > 0");
            sumDataTable.Rows.Add(row);
