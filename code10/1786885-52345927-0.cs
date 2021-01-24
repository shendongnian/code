    using (var con = SQLConnection.GetConnection())
     {
    using (var select = new SqlCommand(SELECT COUNT(0) FROM employee_product WHERE Image = @Image, con)) 
     {
    cmd.Parameters.Add("@Image", SqlDbType.VarBinary).Value = PhotoByte;
    int count = (int)select.ExecuteScalar();
    if (count > 0 ) 
    {
      lbl.Show();
    }
    }
    }
