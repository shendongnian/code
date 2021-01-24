    private void btnExecute_Click(object sender, EventArgs e)
    {
        var frm1 = Application.OpenForms[0] as Form1; //find `Form1` like you want, I only take [0]
        //always create a new instance of SqlConnection here and dispose it with the using Keyword
        //don't use a private field to try to keep the Connection, let the internal Connection pool handle that case
        using (var con = new SqlConnection(@"Data Source=srvr;Initial Catalog =db; User ID =user; Password =pass"))
        {
            try
            {
                con.Open();
                
                //clean up, Command/Reader with using keyword
                using (var cmd = con.CreateCommand())
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
        //should activate the `Form1` AFTER the job is done, you can consider if you only want to activate it if the previous Code didn't fail
        frm1.Activate();
    }
