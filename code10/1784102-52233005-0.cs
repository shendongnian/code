    OleDbConnection con = new OleDbConnection("Provider=sqloledb;SERVER=NEVZAT-PC;DATABASE=DENEME;User ID=11;password=1111;");
    
    using(OleDbCommand cmd = new OleDbCommand("insert into isemri (isemrino,isyeri,isalani,isemridet,bastar,bittar) values (?, ?, ?, ?, ?, ?)", conn))
    {
           cmd.Parameters.AddWithValue("@isemrino", Convert.ToInt32(textBox1.Text) ?? DBNull.Value);
           cmd.Parameters.AddWithValue("@isyeri", comboBox1.Text ?? DBNull.Value);
           cmd.Parameters.AddWithValue("@isalani", comboBox2.Text ?? DBNull.Value);
           cmd.Parameters.AddWithValue("@isemridet", richTextBox1.Text ?? DBNull.Value);
           cmd.Parameters.AddWithValue("@bastar", dateTimePicker1.Value ?? DBNull.Value);
           cmd.Parameters.AddWithValue("@bittar", dateTimePicker2.Value ?? DBNull.Value);
    
    
           con.Open();
           cmd.ExecuteNonQuery();
           con.Close();
    }
