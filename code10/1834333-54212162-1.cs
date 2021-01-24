    string sql = 
      @"insert ignore Attendance(
          Name,
          Date,
          empIn)
        values(
         @Name,
         @Date,
         @empIn)";
    //DONE: wrap IDisposable into using
    using (MySqlCommand cmd = new MySqlCommand(sql, con)) {
      cmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = label3.Text;
      // If Date is DateTime, provide DateTime, not string
      //TODO: provide the right date time format here
      cmd.Parameters.Add("@Date", MySqlDbType.DateTime).Value = 
        DateTime.ParseExact(label1.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
      cmd.Parameters.Add("@empIn", MySqlDbType.VarChar).Value = label2.Text;
      if (cmd.ExecuteNonQuery() > 0)
        MessageBox.Show("Attendance Inserted");
      else
        MessageBox.Show("This data is already IN");
    } 
