    dateTimePicker1.CustomFormat = "yyyy/dd/MM";  
    var qr = "INSERT INTO tbl VALUES (@dtp)";
    using (var insertCommand = new SqlCommand..
    {
       try
       {
         insertCommand.Parameters.AddWithValue("@dtp", dateTimePicker1.Text);
         con.Open();
         insertCommand.ExecuteScalar();
       }
       catch (Exception ex)
       {
          MessageBox.Show("Exception message: " + ex.Message, "DateTimePicker", MessageBoxButtons.OK, MessageBoxIcon.Error);
       }
