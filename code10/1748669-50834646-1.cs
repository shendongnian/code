        private void btn_search_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select top 1 TRANSACTIONNUMBER, PASSENGERNAME from ticketsales where reference=@ref";
                using (SqlDataAdapter adap = new SqlDataAdapter(query, con))
                {
                    con.Open();
                    DataTable dt = new DataTable();
                    adap.SelectCommand.Parameters.AddWithValue("@ref", txtSearch.Text.Trim());
                    adap.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txtTrans.Text = dt.Rows[0]["TRANSACTIONNUMBER"].ToString().Trim();
                        txtPax.Text = dt.Rows[0]["PASSENGERNAME"].ToString().Trim();
                    }
                    else
                    {
                        MessageBox.Show("Ticket Number not Found");
                    }
                }
            }
        }
