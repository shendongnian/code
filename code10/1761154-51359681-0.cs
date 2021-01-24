    public void StartListener()
    {
    try
                {
                    using (SqlConnection connection =
           new SqlConnection(GetConnectionString()))
                    {              
    //i want to return here when the connection is reestablished
    
    using (SqlCommand command =
                        new SqlCommand(GetListenerSQL(), connection))
                        {
                            connection.Open();
    
                            // Make sure we don't time out before the
                            // notification request times out.
                            command.CommandTimeout = NotificationTimeout;
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                messageText = System.Text.ASCIIEncoding.ASCII.GetString((byte[])reader.GetValue(13)).ToString();
                                // Empty queue of messages.
                                // Application logic could parse
                                // the queue data and 
                                // change its notification logic.
                            }
    
                            object[] args = { this, EventArgs.Empty };
                            EventHandler notify =
                            new EventHandler(OnNotificationComplete);
                            // Notify the UI thread that a notification
                            // has occurred.
                            this.BeginInvoke(notify, args);
                        }
                    }
                }
                catch(SqlException e)
                {
                     Thread.Sleep(2000);
                     StartListener();
                }
    }
