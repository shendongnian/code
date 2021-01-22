    DataTable table = new DataTable()
    SqlConnection cnn = new SqlConnection(connectionString);
    
    StreamReader stream = new StreamReader(fileName);                
    
    while (!stream.EndOfStream) {
        string serial = stream.ReadLine();
        SqlDataReader reader = GetCardBySerial(serial, cnn);
        table.Load(reader);
        reader.Close();
    }
    cnn.Close();
    
    public SqlDataReader GetCardBySerial(string serialNo, SqlConnection cnn) {
        SqlCommand cmd = new SqlCommand("Cards_GetCardBySerial", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@serialNo", SqlDbType.NVarChar).Value = serialNo;
        return cmd.ExecuteReader();
    }
