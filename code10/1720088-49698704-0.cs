        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\dbms\jollibee.accdb";
                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                
                //THIS LINE IS THE PROBLEM
                cmd = new OleDbCommand("insert into Employee_Details ([username],[password],[Name],[Middle_Name],[Surname],[address],[account_Type],[Mobile_Number],[BirthDate]) values (?,?,?,?,?,?,?,?,?);");
                cmd.Parameters.AddWithValue("@username", username.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
                cmd.Parameters.AddWithValue("@Name", name.Text);
                cmd.Parameters.AddWithValue("@Middle_Name", middlename.Text);
                cmd.Parameters.AddWithValue("@Surname", surname.Text);
                cmd.Parameters.AddWithValue("@address", address.Text);
                cmd.Parameters.AddWithValue("@account_Type", accountType.Text);
                cmd.Parameters.AddWithValue("@BirthDate", birthdate.Text);
                cmd.Parameters.AddWithValue("@Mobile_Number", mobilenumber.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("done");
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
        }
