    using (var ts = new TransactionScope())
    using (var conn = new SqlConnection(connectionString))
    {
        try {
            conn.Open();
            using (var cmd = new SqlCommand("DELETE FROM dbo.vehicle"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            using (var bc = new SqlBulkCopy(conn))
            {
                bc.DestinationTableName = "vehicle";
                bc.BatchSize = vehicleData.Rows.Count;
                bc.WriteToServer(vehicleData);
            }
            ts.Complete(); // Commit
        } catch (Exception ex) {
            //TODO: handle exception
        }
    }
