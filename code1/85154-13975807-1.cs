    private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
                textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                con.Open();
                sql = "select *from Table_Name;
                cmd = new SqlCommand(sql, con);
                SqlDataReader sdr = null;
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    col.Add(sdr["Column_Name"].ToString());
                }
                sdr.Close(); 
               
                textBox1.AutoCompleteCustomSource = col;
                con.Close();
            }
            catch
            {
            }
        }
