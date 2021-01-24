    public void RefreshGrid_parts()
    {
        ConnectionStringSettings conSettings = ConfigurationManager.ConnectionStrings["shopmanagerConnectionString1"];
        MySqlConnection con = new MySqlConnection(conSettings.ToString());
        con.Open();
        MySqlCommand cmd = new MySqlCommand("select * from shopmanager.parts where quotes_idquotes = '" + temp_quote.quote_id + "';",con);
        DataTable dt = new DataTable();
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        da.Fill(dt);
        dataGridView1.AutoGenerateColumns = true;
        //dataGridView1.ColumnCount = 6;
        //dataGridView1.Columns[0].HeaderText = "# Assembly";
        //dataGridView1.Columns[0].DataPropertyName = "assemblies_assembly_id";
        //dataGridView1.Columns[1].HeaderText = "# Part";
        //dataGridView1.Columns[1].DataPropertyName = "part_number";
        //dataGridView1.Columns[2].HeaderText = "# Item";
        //dataGridView1.Columns[2].DataPropertyName = "items_items_id";
        //dataGridView1.Columns[3].HeaderText = "# Description";
        //dataGridView1.Columns[3].DataPropertyName = "part_description";
        //dataGridView1.Columns[4].HeaderText = "Drawing Revision";
        //dataGridView1.Columns[4].DataPropertyName = "drawing_rev";
        //dataGridView1.Columns[5].HeaderText = "Quantity";
        //dataGridView1.Columns[5].DataPropertyName = "quantity";
        dataGridView1.DataSource = dt;
        con.Close();
    }
