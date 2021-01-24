    public async void SendCommand(string command)
    {
       PacketModel packet = new PacketModel()
       {
         Identifier = 1,
         Message = command,
         Name = "RustManager"
       };
       string packetString = JsonConvert.SerializeObject(packet);
       var result = await _webSocket.SendAsync(packetString, null);
    }
