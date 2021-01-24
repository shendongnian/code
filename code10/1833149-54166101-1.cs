    using (var con = new OleDbConnection())
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
                MessageBox.Show("Incorrect Username or Password");
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }
    }
