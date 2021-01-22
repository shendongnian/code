    public void AutoComplete()
    {
        try
        {
            MySqlConnection conn = new 
            MySqlConnection("server=localhost;database=databasename;user
                id=root;password=;charset=utf8;");
            MySqlCommand cmd = new MySqlCommand("select distinct
                (columnName) from tablename", conn);
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds, "tablename");
            AutoCompleteStringCollection col = new
            AutoCompleteStringCollection();
            int i = 0;
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                col.Add(ds.Tables[0].Rows[i]["columnName"].ToString());
            }
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboBox1.AutoCompleteCustomSource = col;
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
        MessageBoxIcon.Error);
        }
    }
