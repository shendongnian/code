     DataTable dt = new DataTable();
        foreach (var itm in sampleList) {
            DataRow row = dt.NewRow();
            row["Field1"] = itm.Field1;
            row["Field2"] = itm.Field2;
            row["Field3"] = itm.Field3;
            dt.Rows.Add(row);
        }
        using (SqlConnection cn = new SqlConnection(connectionString)) {
            cn.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(cn)) {
                bulkCopy.DestinationTableName = "dbo.Categories";
                bulkCopy.WriteToServer(dt);
            }
            cn.Close();
        }
