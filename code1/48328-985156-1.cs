            TcpListener listener = new TcpListener(address, port);
            listener.Start();
            try
            { 
                using (TcpClient client = listener.AcceptTcpClient())
                {
                    stream = client.GetStream();
                    IFormatter formatter = new BinaryFormatter();
                    while (true)
                    {
                        MessageData data = (MessageData)formatter.Deserialize(stream);
                        if (ImageReceivedEvent != null) ImageReceivedEvent(data.Picture);
                    }
                }
            }
