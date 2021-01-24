    using (var con = new OleDbConnection())
    {
        con.Open();
    
        using (var cmd = new OleDbCommand())
        {
            cmd.Connection = con;
            cmd.CommandText = "select * from SignUp where Username = ? and Password = ?";
            cmd.Parameters.Add(textBox1.Text);
            cmd.Parameters.Add(textBox2.Text);
    
            using (var dr = cmd.ExecuteReader())
            {
                int count = 0;
                while (dr.Read())
                {
                    count++;
                }
                if (count == 1)
                {
                    MainMenu menu = new MainMenu();
                    menu.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password");
                }
            }
        }
    }
