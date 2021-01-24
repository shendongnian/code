        private void autogen()
        {
            try
            {
                conn.Open();
                String count = "SELECT max(id) + 1 as a from tbl_user";
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
