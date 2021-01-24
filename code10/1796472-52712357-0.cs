    private void button1_Click(object sender, EventArgs e)
    {
       //Load Data
       try
       {
          string conString = ConfigurationManager.ConnectionStrings[comboBox1.Text].ConnectionString;
          OracleConnection con = new OracleConnection(conString);
          con.Open();
          da = new OracleDataAdapter("sql command", con);
          ds = new DataSet();
          cmdbld = new OracleCommandBuilder(da);
          da.Fill(ds);
          dataGridView1.DataSource = ds.Tables[0];
       }
       catch (Exception ex)
       {
            MessageBox.Show(ex.Message);
       }
       finally
       {
           con.Close();
       }
    }
