    using (var conn = new OracleConnection(connectionString))
    using (var cmd = new OracleCommand("ProcedureName", conn) { 
                           CommandType = CommandType.StoredProcedure }) {
    conn.Open();
    using(OracleDataReader reader = cmd.ExecuteReader())
     {
       DataTable dataTable = new DataTable();
       dataTable.Load(reader);
       dataGridView1.DataSource = dataTable;
     }
     conn.Close();
