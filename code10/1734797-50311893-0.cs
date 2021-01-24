    try
        {
            string user, pass;
            user = txtUsername.Text; // You don't need Convert.ToString as TextBox.Text is already string. 
            pass = txtPassword.Text;
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            var query = "SELECT * FROM Login WHERE Username = '" +user+ "' AND Password = '" + pass + "' ";
            OleDbDataAdapter da = new OleDbDataAdapter(query, con);             
            DataSet ds = new DataSet();
            da.Fill(ds); //Populate data set via adapter.
            
            DataTable dt = ds.Tables[0]; //Get the first table from the dataset
            int count = dt.Rows.Count;
            
            if (count == 1)
            {
                MessageBox.Show("Login Success!");
                this.Hide();
                if (dt.Rows[0][0].ToString()=="admin")
                {
                    frmHome home = new frmHome();
                    home.Show();
                    Visible = false;
                }
                else if (dt.Rows[0][0].ToString() == "staff")
                {
                    frmAdminHome ah = new frmAdminHome();
                    ah.Show();
                    Visible = false;
                }
            }
            else if (count > 1)
            {
                MessageBox.Show("Duplicate username and password!");
            }
            else
            {
                MessageBox.Show("Username and Password is not correct!");
            }
            con.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("ERROR" + ex);
        }
