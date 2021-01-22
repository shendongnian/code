    To AutoComplete TextBox Control in C#.net windows application using 
    wamp mysql database...
    here is my code..
    AutoComplete();
    write this **AutoComplete();** text in form-load event..
    private void Autocomplete()
        {
            try
            {
                MySqlConnection cn = new MySqlConnection("server=localhost;
    database=databasename;user id=root;password=;charset=utf8;");
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT distinct Column_Name
         FROM table_Name", cn);
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "table_Name");
                AutoCompleteStringCollection col = new   
                AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["Column_Name"].ToString());
                }
                textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox1.AutoCompleteCustomSource = col;
                textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
           MessageBoxIcon.Error);
            }
        }
