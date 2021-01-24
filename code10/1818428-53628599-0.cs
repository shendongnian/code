       public void cc()
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Department from tbldept";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                Da.Fill(dt);
        
                 if (dt!= null && dt.Rows.Count > 0)
                        {
                            comboBox1.DisplayMember = "Department ";
                            comboBox1.ValueMember = "Department ";
                            comboBox1.DataSource = dt;                    
                        }
                conn.Close();
            }
