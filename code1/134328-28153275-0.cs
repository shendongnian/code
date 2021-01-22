    SqlConnection add = new SqlConnection(ConfigurationManager.ConnectionStrings["sismanager"].ConnectionString);
            SqlCommand additem = new SqlCommand("INSERT INTO Godown(Gname, Gstock) VALUES(@Gname, @Gstock)", add);
            additem.Parameters.AddWithValue("@Gname", textBox1.Text.Trim());
            additem.Parameters.AddWithValue("@Gstock", textBox2.Text.Trim());
            try
            {               
                add.Open();
                additem.ExecuteNonQuery();              
            }
            catch
            {
            }
            finally
            {
                add.Close();
                
                dataGridView1.Columns.Clear();
                SqlConnection setcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sismanager"].ConnectionString);
                using (SqlCommand getdata = new SqlCommand("SELECT Gid, Gname, Gstock FROM Godown ORDER BY Gname ASC", setcon))
                {
                    setcon.Open();
                    SqlDataAdapter da = new SqlDataAdapter(getdata);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        comboBox1.DisplayMember = "Gname";
                        comboBox1.ValueMember = "Gid";
                        comboBox1.DataSource = dt;
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[0].HeaderText = "Item Id";
                        dataGridView1.Columns[1].HeaderText = "Item";
                        dataGridView1.Columns[2].HeaderText = "Item Stock";
                        DataGridViewButtonColumn deletebtn = new DataGridViewButtonColumn();
                        dataGridView1.Columns.Add(deletebtn);
                        deletebtn.HeaderText = "Remove";
                        deletebtn.Text = "Remove";
                        deletebtn.Name = "Dbtn";
                        deletebtn.UseColumnTextForButtonValue = true;
                    }
                    else
                    {
                        MessageBox.Show("No Stock Items to Show", "Stock Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }    
