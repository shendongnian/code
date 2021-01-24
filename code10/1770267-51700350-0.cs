    SqlConnection conn = new SqlConnection("Data Source=;Initial Catalog=;Persist Security Info=True;User ID=;Password=");
    conn.Open();
    String q = "Select * from table"';
    SqlCommand command = new SqlCommand(q, conn);
    SqlDataReader r = command.ExecuteReader();
    while(r.read())
    { 
    	comboBox1.Items.Add(r["index"].toString());    
    }
       
    conn.Close();
