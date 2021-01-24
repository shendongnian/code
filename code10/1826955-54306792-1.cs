    using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["MetricBroadcast.Properties.Settings.TargetConnectionString"].ToString()))
    {
        string messtype = "";
        Guid convhandle = new Guid();
    
        cnn.Open();
        trans = cnn.BeginTransaction("queuetrans");
    
        // Create the command to monitor the Notifications Queue
        //
        using (SqlCommand cmd = new SqlCommand("WAITFOR ( RECEIVE * FROM dbo.NotificationsQueue);", cnn, trans))
        {
            cmd.CommandTimeout = 0;
    
            // Execute the command - we will wait here until a new entry appears in the Notification Queue
            //
            SqlDataReader reader = cmd.ExecuteReader();
    
            // Get the message text from the reader
            //
            while (reader.Read())
            {
                // Get the message body text and convert into a legible format
                //
                messtype = reader.GetString(reader.GetOrdinal("message_type_name"));
                convhandle = reader.GetGuid(reader.GetOrdinal("conversation_handle"));
    
                if (messtype == @"http://schemas.microsoft.com/SQL/Notifications/QueryNotification")
                {
                    messageText = System.Text.UTF8Encoding.Unicode.GetString(reader.GetSqlBinary(reader.GetOrdinal("message_body")).Value);
                }
            }
    
            reader.Close();
            reader = null;
    
    
            if (messtype == @"http://schemas.microsoft.com/SQL/ServiceBroker/EndDialog" ||
                messtype == @"http://schemas.microsoft.com/SQL/ServiceBroker/Error")
            {
                var cmd2 = new SqlCommand("end conversation '" + convhandle.ToString() + "'", cnn, trans);
    
                cmd2.ExecuteNonQuery();
    
                cmd2.Dispose();
            }
    
            trans.Commit();
        }
    }
