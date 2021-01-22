    public async void listen(dataHandler processDataFuc)
    {
        NetworkStream stream;
        Byte[] data_buffer = new Byte[MAX_PACKET_SIZE];
        if(!this.Connected)
            this.Connect();
        stream = main_client.GetStream();
        while (!this.terminate_listening)
        {            
            await stream.ReadAsync(data_buffer, 0, data_buffer.Length)
            processDataFuc(data_buffer);
        }
    }  
