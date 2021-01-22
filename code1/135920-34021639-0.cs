    DataTable dT;
    BindingSource bS;
    
    using (SqlCeConnection yourConnection = new SqlCeConnection("Data Source=|DataDirectory|\\YourDatabase.sdf"))
    {
        dT = new DataTable();
        bS = new BindingSource();    
    
        string query = "SELECT * FROM table01";
        SqlCeDataAdapter dA = new SqlCeDataAdapter(query, yourConnection);
        SqlCeCommandBuilder cBuilder = new SqlCeCommandBuilder(dA);
        dA.Fill(dT);
        
        bS.DataSource = dT;
        dgv01.DataSource = bS;
    }
