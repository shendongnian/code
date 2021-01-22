        private void on_data_received(IAsyncResult ar)
        {
            try
            {
                int bytesRead = Client.Client.EndReceive(ar);
                if (bytesRead > 0)
                {
                    byte[] data = new byte[bytesRead];
                    Array.Copy(m_message, data, bytesRead);
                    m_coder.Push(data);
                    Client.Client.BeginReceive(m_message, 0, m_message.Length,
                        SocketFlags.None, new AsyncCallback(on_data_received), null);
                }
                else
                {
                    //TODO Close the connection
                }
                             
            }
            catch(Exception ex)
            {
                Console.WriteLine("Connection::on_data_received : {0}", ex.Message);
                handle_connection_lost(new ConnectionLostArgs(Id));
            }
        }
