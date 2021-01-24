    Imports System.Data.OleDb    //Preferably placed before the form load code ie. Top of the page 
    Dim connection As OleDbConnection = New OleDbConnection //Code below, including this is written in the "create profile" button block
                connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\LoginDB.accdb" //Here, LoginDB is the name of your MS Access file.
                connection.Open()
                Dim updatequery As OleDbCommand = New OleDbCommand("INSERT INTO LoginTable (FullName,ProfileName,Email,Password) VALUES(@name1,@name2,@email,@pass)", connection) //LoginTable being the name of the table created inside MS Access file.
                updatequery.Parameters.Add("@name1", OleDbType.VarChar).Value = TextBox1.Text
                updatequery.Parameters.Add("@name2", OleDbType.VarChar).Value = TextBox2.Text
                updatequery.Parameters.Add("@email", OleDbType.Numeric).Value = TextBox3.Text
                updatequery.Parameters.Add("@pass", OleDbType.Numeric).Value = TextBox4.Text
                updatequery.ExecuteNonQuery()
                connection.Close()
