    int bw = 0;
    private void timer1_Tick(object sender, EventArgs e)
            {
                bw = Convert.ToInt32(lblBytesReceived.Text) - bw;
                SqlCommand comnd = new SqlCommand("insert into tablee (bandwidthh,timee) values ("    + bw.ToString() + ",@timee)", conn);
                conn.Open();
                comnd.Parameters.Add("@timee",System.Data.SqlDbType.Time).Value = DateTime.Now.TimeOfDay;
                comnd.ExecuteNonQuery();
                conn.Close();
            }
