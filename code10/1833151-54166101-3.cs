    using (var con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Assignment.accdb"))
    {
        con.Open();
    
        using (var cmd = new OleDbCommand())
        {
            cmd.Connection = con;
            cmd.CommandText = "select * from SignUp where Username = ? and Password = ?";
            cmd.Parameters.Add(textBox1.Text);
            cmd.Parameters.Add(textBox2.Text);
            var result = cmd.ExecuteScalar();
            if (result == null)
            {
                MessageBox.Show("Incorrect Username or Password");
                return;
            }
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }
    }
