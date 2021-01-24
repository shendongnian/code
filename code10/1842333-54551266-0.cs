    var filterConditions = new[] {
           CreateSqlFilter("CIVILIDD", ID_No, selectCommand, false),
    };
            string filterCondition = filterConditions.Any(a => a != null) ? filterConditions.Where(a => a != null).Aggregate((filter1, filter2) => String.Format("{0} AND {1}", filter1, filter2)) : (string)null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["my"].ConnectionString))
            {
                selectCommand.Connection = connection;
                selectCommand.CommandText = filterCondition == null ? "SELECT * FROM _4" : "SELECT * FROM _4 WHERE " + filterCondition;
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                DataTable dataSource = new DataTable();
                adapter.Fill(dataSource);
                dataGridView2.DataSource = dataSource;
                using (SqlCommand command2 = new SqlCommand("SELECT * FROM [_4] WHERE CIVILIDD = @id", mycon))
                {
                    command2.Parameters.AddWithValue("@id", ID_No.Text);
                    SqlDataReader dr = command2.ExecuteReader();
                    while (dr.Read())
                    {
                        txtname1.Text = (dr["name1"].ToString());
                        txtname2.Text = (dr["name2"].ToString());
                        Governorate.Text = (dr["Governorate"].ToString());
                        City.Text = (dr["City"].ToString());
                        Block.Text = (dr["Block"].ToString());
                        Street.Text = (dr["Street"].ToString());
                        Avenue.Text = (dr["Avenue"].ToString());
                        House.Text = (dr["House"].ToString());
                        Floor.Text = (dr["Floor"].ToString());
                        flat.Text = (dr["flat"].ToString());
                    }
                     // Close and Dispose the datareader
                     dr.Close();
                     dr.Dispose();
                }
            }
