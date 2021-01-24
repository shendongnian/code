    private Task _receiving;
    private void Receive()
    {
      if(_clientSocket.ReceiveBufferSize > 0)
        {
        if(_receiving == null || _receiving.IsCompleted)
         _receiving = Task.Run(() => 
         {
            byte[] receivedBuffer = new byte[1024];
            int rec = _clientSocket.Receive(receivedBuffer);
            byte[] data = new byte[rec];
            Array.Copy(receivedBuffer, data, rec);
            Messageslb.Items.Add(Encoding.ASCII.GetString(data)); 
         });
     }
    }
