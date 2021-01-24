    using (var conn = new OracleConnection(connectionString))
    using (var cmd = new OracleCommand("ProcedureName", conn) { 
                           CommandType = CommandType.StoredProcedure }) {
    conn.Open();
    using(OracleDataAdapter da = new OracleDataAdapter (cmd))
     {
       DataTable dataTable = new DataTable();
       da.Fill(dataTable);
       dataGridView1.DataSource = dataTable;
     }
     conn.Close();
