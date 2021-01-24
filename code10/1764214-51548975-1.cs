        private void autogen()
        {
            try
            {
                conn.Open();
                String count = "SELECT auto_increment as a from information_schema.tables where table_schema = 'ldlb_lib' and table_name = 'tbl_user'";
                MySqlDataAdapter sda = new MySqlDataAdapter(count, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                String strgen = Convert.ToInt32(dt.Rows[0]["a"].ToString()).ToString("D3");
                MySqlCommand comm = new MySqlCommand("SELECT * FROM tbl_user WHERE userid = '" + "LDLB" + strgen + "'", conn);
                MySqlDataReader reader;
                reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    strgen = (int.Parse(strgen) + 1).ToString();
                }
                conn.Close();
                lblUID.Text = "LDLB" + strgen;
            }
            catch (Exception et)
            {
                MessageBox.Show(et.Message);
            }
        }
