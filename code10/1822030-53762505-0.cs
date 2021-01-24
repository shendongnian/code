    private void btnExecute_Click(object sender, EventArgs e)
    {
        var frm1 = Application.OpenForms[0]; //find `Form1` like you want, I only take [0]
        frm1.Activate();
        //always create a new instance of SqlConnection here and dispose it with the using Keyword
        //don't use a private field to try to keep the Connection, let the internal Connection pool handle that case
        using (var con = new SqlConnection(@"Data Source=srvr;Initial Catalog =db; User ID =user; Password =pass"))
        {
            try
            {
                Conn.Open();
                
                //clean up, Command/Reader with using keyword
                using (var cmd = Conn.CreateCommand())
                {
                    cmd.CommandText = txtQuery.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //read data
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing command.\n" + ex.Message);
            }
        }
    }
