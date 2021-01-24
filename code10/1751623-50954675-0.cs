    private void button1_Click(object sender, EventArgs e)
    {
        string query = "INSERT INTO t(SerialNumber,UserName,Password) VALUES (@serial, @user, @pass);";
        var dbdataset = new DataTable();
        //ADO.Net does better if you create new objects, rather than try to re-use them through a class or application.
        // The "using" blocks will make sure things are closed and disposed properly, even if an exception is thrown
        using (var conn = new SqlConnection(@"Data Source=MIRAZ-PC\SQLEXPRESS;Initial Catalog=2DArrayIntoDatabaseTest;Integrated Security=True"))
        using (var cmd = new SqlCommand(query, conn))
        {   
            cmd.Parameters.Add("@serial", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@user", SqlDbType.NVarChar, 20);  
            cmd.Parameters.Add("@pass", SqlDbType.NVarChar, 20);
            conn.Open();
            for (i = 0; i < 2; i++)
            {
                cmd.Parameters["@serial"].Value = LoginInfo[i, 0];
                cmd.Parameters["@user"].Value = LoginInfo[i, 1];
                cmd.Parameters["@pass"].Value = LoginInfo[i, 2];
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            cmd.CommandText = "SELECT * FROM t";
            var sda = new SqlDataAdapter(cmd);
            try
            {
                sda.Fill(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        dataGridView1.DataSource = dbdataset;
    }
