    DateTime? beginDate = DateTime.now;
    DateTime? endDate = null;
    using (SqlCommand command = new SqlCommand("select * from FnEmployeeProduction (@begin, @end)");
    {  
        command.Parameters.Add("@begin", SqlDbType.DateTime).Value = (beginDate == null) ? (object)DBNull.Value : beginDate;
        command.Parameters.Add("@end", SqlDbType.DateTime).Value = (endDate == null) ? (object)DBNull.Value : endDate;
        // now you can use this command object to send to your DB
        using (SqlConnection connection = new SqlConnection(your conn string))
        {  
           using (SqlDataAdapter adapter = new SqlDataAdapter(command))
           {
               adapter.Fill(your datatable);
           }
        }
    }
