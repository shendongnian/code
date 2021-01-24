    while(true)
            {
                string data = Encoding.Unicode.GetString(buffer, 0, 
    streamer.Read(buffer, 0, client.ReceiveBufferSize));
                if(data == "Response_Command_329873123709123")
                {
                    MessageBox.Show(Encoding.Unicode.GetString(buffer, 0, 
    streamer.Read(buffer, 0, client.ReceiveBufferSize)), "Client Response");
                }
            }
