    String CommandLine = "UPDATE CA_temp_data SET TimePast=@selectTot WHERE TicketNumber=@id";
    using (SqlConnection Conn = new SqlConnection("Data Source=" + hostString + ";User ID=" + usernamestring + ";Password=" + sqlpassword))
    {
          try
          {
              SqlCommand cmd = new SqlCommand(CommandLine, Conn);
              cmd.Parameters.AddWithValue("@id", ticket);
              cmd.Parameters.AddWithValue("@selectTot", time);
          using (Conn)
          {
                Conn.Open();
                cmd.ExecuteNonQuery();
                Conn.Close();
          }
    }
    catch (System.Exception excep)
    {
    }
