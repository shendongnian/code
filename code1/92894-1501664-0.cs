     public DataSet BookingCheck(int duration_of_stay, int number_of_guests,
        string date_of_application, string date_of_checkin, string date_of_checkout,
        string room_type, out string message)
    {
        DataSet dsGetBookingCheck = new DataSet();
        SqlConnection conn = new SqlConnection(Con);
        SqlCommand command = new SqlCommand("BookingCheck", conn);
        command.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter();
        SqlParameter param = new SqlParameter();
        param = command.Parameters.Add("@int_duration_of_stay", SqlDbType.Int);
        param.Value = duration_of_stay;
        param = command.Parameters.Add("@int_number_of_guests", SqlDbType.Int);
        param.Value = number_of_guests;
        param = command.Parameters.Add("@date_of_application", SqlDbType.Date);
        param.Value = date_of_application;
        param = command.Parameters.Add("@date_of_checkin", SqlDbType.Date);
        param.Value = date_of_checkin;
        param = command.Parameters.Add("@date_of_checkout", SqlDbType.Date);
        param.Value = date_of_checkout;
        param = command.Parameters.Add("@str_room_type", SqlDbType.VarChar, 50);
        param.Value = room_type;
        command.Parameters.Add("@ret_value", SqlDbType.String);
        command.Parameters["@ret_value"].Direction = ParameterDirection.Output;
        conn.Open();
        command.ExecuteNonQuery();
        da.SelectCommand = command;
        da.Fill(dsGetBookingCheck);
        message = command.Parameters["@ret_value"].Value.ToString();
        conn.Close();
        return dsGetBookingCheck;
    }
