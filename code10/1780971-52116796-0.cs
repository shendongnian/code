    public void RefreshGrid_parts()
        {
            ConnectionStringSettings conSettings = ConfigurationManager.ConnectionStrings["shopmanagerConnectionString1"];
            MySqlConnection con = new MySqlConnection(conSettings.ToString());
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select assemblies_assembly_id as '# Assembly', part_number as '# Part', items_items_id as '# Item', part_description as '# Description', drawing_rev as 'Drawing Revision', quantity as 'Quantity'  from shopmanager.parts where quotes_idquotes = $1;",con);
            cmd.Parameters.Add(new MySqlParameter("$1", temp_quote.quote_id) { DbType = DbType.Int32 });
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
    
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dt;
    
            con.Close();
        }
