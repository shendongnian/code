    comm.CommandType = CommandType.Text;
    comm.CommandText = "BEGIN :ret := cv(:x, :y, :z); END;";
    comm.Parameters.Add("x", OracleType.Number).Value = comboBox1.Text;
    comm.Parameters.Add("y", OracleType.Number).Value = comboBox2.Text;
    comm.Parameters.Add("z", OracleType.VarChar2).Value = "some text";
    comm.Parameters.Add("ret", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
    
    OracleDataAdapter da = new OracleDataAdapter(comm);
    DataTable dt = new DataTable();
    da.Fill(dt);
    dataGridView1.DataSource = dt;
