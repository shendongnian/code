            StreamSocketListener listener = new StreamSocketListener();
            listener.ConnectionReceived += OnConnection;
        private async void OnConnection(
            StreamSocketListener sender, 
            StreamSocketListenerConnectionReceivedEventArgs args)
        {
            DataReader reader = new DataReader(args.Socket.InputStream);
            try
            {
                while (true)
                {
                    // Read first 4 bytes (length of the subsequent string).
                    uint sizeFieldCount = await reader.LoadAsync(sizeof(uint));
                    if (sizeFieldCount != sizeof(uint))
                    {
                        // The underlying socket was closed before we were able to read the whole data.
                        //Detect disconnection
                        return;
                    }
                    // Read the string.
                    uint stringLength = reader.ReadUInt32();
                    uint actualStringLength = await reader.LoadAsync(stringLength);
                    if (stringLength != actualStringLength)
                    {
                        // The underlying socket was closed before we were able to read the whole data. 
                        //Detect disconnection
                        return;
                    }
                    //TO DO SOMETHING
                }
            }
            catch (Exception exception)
            {
                 //TO DO SOMETHING
            }
        }
