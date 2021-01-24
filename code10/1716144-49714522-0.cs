    for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                string constring = "datasource=localhost;port=3306;username=root";
                string query = "insert into maasinhondb.orderdetails_table (order_id, pig_id, flavor_id, internal_id) values ('" + this.txtOID.Text + "', @pigid,@flavorid,@internalid);";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(query, conDataBase);
                MySqlDataReader myReader;
                    cmdDataBase.Parameters.AddWithValue("@pigid", dataGridView2.Rows[i].Cells[0].Value);
                    cmdDataBase.Parameters.AddWithValue("@flavorid", dataGridView2.Rows[i].Cells[4].Value);
                    cmdDataBase.Parameters.AddWithValue("@internalid", dataGridView2.Rows[i].Cells[7].Value);
                    //cmdDataBase.Parameters.Clear();
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    while (myReader.Read())
                    {
                    }
                    conDataBase.Close();
            }
