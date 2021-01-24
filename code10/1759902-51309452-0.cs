    void get_mada_listbox()
        {
            var connection = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            using (SqlConnection connsql = new SqlConnection(connString))
            {
                connsql.Open();
                // Sql Adapter
                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter("SELECT * FROM DataTable", connection))
                {            
                    // fill a data table
                    var data_table = new DataTable();
                    sqlAdapter.Fill(t);
                    // Bind the table to the list box
                    listBox1.DisplayMember = "mada_name";
                    listBox1.ValueMember = "mada_value";
                    listBox1.DataSource = data_table;
                }
            }
        }
