    DateTime date;
    if(!DateTime.TryParse(textBox1.Text, out date))
    {
        //Do whatever you need to indicate a bad date.
    }
    using(var con = new OleDbConnection(cs))
	{
		con.Open();        
		String sql = "SELECT * From Sales where InvoiceDate = @date"; 
		using(var cmd = new OleDbCommand(sql, con))
		{
			cmd.Parameters.Add("@date", /*Insert correct type here*/).Value = date;
			DataTable dt = new DataTable(); 
			dt.Load(cmd.ExecuteReader()); 
			dataGridView1.DataSource = dt; 
		}
	}
