    con.Open();
	string column = this.label4.Text;                                       
	string XXX = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);  
    StringBuilder sb = new StringBuilder("SELECT * FROM tblTable WHERE 1=1");
    if(column == "...")
    {
        sb .Append(" column=@XXX...");
    }
	SqlCommand cmd9 = new SqlCommand(sb.ToSTring(), con);
	cmd9.Parameters.Add("@XXX", SqlDbType.NVarChar, -1);
	cmd9.Parameters["@XXX"].Value = XXX;
	SqlDataAdapter adapter9 = new SqlDataAdapter(cmd9);  //to view data in DataGridview I need a "data adapter" and "data set"
	DataSet ds9 = new DataSet();
	adapter9.Fill(ds9, "tblTable");
	dataGridView1.DataSource = ds9.Tables["tblTable"];
	con.Close();
