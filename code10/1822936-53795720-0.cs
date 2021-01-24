    private void button1_Click(object sender, EventArgs e)
    {
        string sqla = @"BEGIN EXECUTE IMMEDIATE 'alter tablespace " + label1.Text + " add datafile '" + textBox1.Text + "' size " + textBox2.Text +"M'; END;";
        OracleConnection conn3 = new OracleConnection(); 
        conn3.ConnectionString = connectform.connectionString;
        conn3.Open(); 
        OracleCommand cmd3 = new OracleCommand("sqla", conn3);
        cmd3.CommandType = CommandType.Text;
        cmd3.ExecuteNonQuery();
        conn3.Close();
    }
