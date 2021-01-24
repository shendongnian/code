     void Load_Products()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM FileFolderPath", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    string pid = dt.Rows[i]["Id"].ToString() as string;
                    string p = dt.Rows[i]["Product"].ToString();
                    comboBox2.Items.Add(p);
                    comboBox2.DisplayMember = p;
                    comboBox2.ValueMember = pid.ToString() as string;
                }
            }
            catch (Exception lp)
            {
                MessageBox.Show(lp.Message);
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var ppat = "SELECT * FROM FileFolderPath WHERE Id = '" + comboBox2.SelectedIndex + "' ++1";
                SqlCommand cmd = new SqlCommand(ppat, conn);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    
                    PID.Text = dr["Id"].ToString();
                    PPath.Text = dr["FolderPath"].ToString();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
