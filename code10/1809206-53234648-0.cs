    private void button1_Click(object sender, EventArgs e)
    {
        OleDbCommand updateQuery = new OleDbCommand("INSERT INTO Profiles (FullName,ProfileName,Email,Password,CardNumber,EXPMonth,EXPYear,CVV) VALUES(@name1,@name2,@email,@pass,@card,@expm,@expy,@cvv)", connection);
        updateQuery.Parameters.Add("@name1", OleDbType.VarChar).Value = textBox4.Text; //FullName
        updateQuery.Parameters.Add("@name2", OleDbType.VarChar).Value = textBox1.Text; //Profile Name
        updateQuery.Parameters.Add("@email", OleDbType.Numeric).Value = textBox2.Text; //Email
        updateQuery.Parameters.Add("@pass", OleDbType.Numeric).Value = textBox3.Text;  //Pass
        updateQuery.Parameters.Add("@card", OleDbType.VarChar).Value = textBox5.Text;  //CardNumber
        updateQuery.Parameters.Add("@expm", OleDbType.Numeric).Value = comboBox1.Text; //EXPMonth
        updateQuery.Parameters.Add("@expy", OleDbType.Numeric).Value = comboBox2.Text; //EXPYear
        updateQuery.Parameters.Add("@cvv", OleDbType.VarChar).Value = textBox7.Text;   //CVV
        updateQuery.ExecuteNonQuery();
        connection.Close();
        MessageBox.Show("Profile Saved");
    }
