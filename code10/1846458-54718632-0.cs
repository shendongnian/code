        private void button1_Click(object sender, EventArgs e)
        {
            int RetVal;
            using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = C:\Users\RBA\Desktop\123\users1.mdb;Persist Security Info=False;"))
            {
                using (OleDbCommand cmd = new OleDbCommand("Select Count(*) From DataData Where [user] = @User And [password] = @password;", connection))
                {
                    cmd.Parameters.Add("@User", OleDbType.VarChar).Value = text_Username.Text;
                    cmd.Parameters.Add("@Password", OleDbType.VarChar).Value = text_Password.Text;
                    connection.Open();
                    RetVal = (int)cmd.ExecuteScalar();
                }
            }
            if (RetVal == 1)
                MessageBox.Show("Welcome");
            else
                MessageBox.Show("Login incorrect");
        }
