    private void btnupdate_Click(object sender, EventArgs e)
    {
        if (txtfno.Text == "" && txtslab.Text == "")
        {
            MessageBox.Show("Updation not possible");
        }
        else
        {
            try
            {
                byte[] img1 = File.ReadAllBytes(@"C:\Users\Admin\Desktop\Final Project Bridger\Bridger\Bridger\Images\20green.png");
                var sql = "update Slab set indi=@indi where s_flatno=@s_flatno and s_name=@s_name";
                // I'm assuming SQL Server based on the error message
                using(var cnn = new SqlConnection(connectionString))
                {
                    using(var cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add("@indi", SqlDbType.VarBinary).Value = img1;
                        cmd.Parameters.Add("@s_flatno", SqlDbType.VarChar).Value = txtfno.Text;
                        cmd.Parameters.Add("@s_name", SqlDbType.VarChar).Value = txtslab.Text;
                    }
                    cnn.Open();
                    cmd3.ExecuteNonQuery();
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
