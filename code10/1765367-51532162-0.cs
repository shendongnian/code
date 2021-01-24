      public void button9_Click(object sender, EventArgs e)
            {  
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
    
                    string column = this.label4.Text;                                       //column is the variable/value which I get when selecting "sort by" button
                    string XXX = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);  //XXX is the variable/value which I get when comboBox item is selected
    
                    StringBuilder sb = new StringBuilder();
                    
                    //1
                    if (column == "AAA")
                    {
                        sb.Append("SELECT * FROM tblTable_values WHERE ").Append(column).Append(" =@XXX");
                    }
                    //2
                    if (column == "BBB")
                    {
                        sb.Append("SELECT * FROM tblTable_values WHERE ").Append(column).Append(" =@XXX");
                    }
                    //3
                    if (column == "CCC")
                    {
                        sb.Append("SELECT * FROM tblTable_values WHERE ").Append(column).Append(" =@XXX");
                    }
                    //4
                    if (column == "DDD")
                    {
                        sb.Append("SELECT * FROM tblTable_values WHERE ").Append(column).Append(" =@XXX");
                    }
                    //5
                    if (column == "EEE")
                    {
                        sb.Append("SELECT * FROM tblTable_values WHERE ").Append(column).Append(" =@XXX");
                    }
                    //6
                    if (column == "FFF")
                    {
                        sb.Append("SELECT * FROM tblTable_values WHERE ").Append(column).Append(" =@XXX");
                    }
    
                    SqlCommand cmd9 = new SqlCommand(sb.ToString(), con);
    
                    cmd9.Parameters.Add("@XXX", SqlDbType.NVarChar, -1);
                    cmd9.Parameters["@XXX"].Value = XXX;
    
    
                    SqlDataAdapter adapter9 = new SqlDataAdapter(cmd9);  //to view data in DataGridview I need a "data adapter" and "data set"
                    DataSet ds9 = new DataSet();
                    adapter9.Fill(ds9, "tblTable_values");
    
                    dataGridView1.DataSource = ds9.Tables["tblTable_values"];
    
                    con.Close();
    
                 }
