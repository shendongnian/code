    MySqlConnection con = new SqlConnection( "datasource = 127.0.0.1;port=3306;username = root;password =; database = test123; SslMode=None ;Convert Zero Datetime=True");
    MySqlCommand cmd = new SqlCommand( "select * from test123.task;", con);
    con.open();
    MySqlDataReader dr= cmd.ExecuteReader();
    
    int top=100;
    While(dr.read())
    {
     Textbox textBox= new TextBox();
     panel2.Controls.Add(textBox);
     textBox.Text=dr[0 /* or instead of 0 use your fieldName */].ToString();
     textBox.Left=150;
     textBox.Top=top;
     top+=100;
    }
     
     con.close()
