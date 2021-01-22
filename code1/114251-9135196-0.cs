    public void Send(ICommand command)
    {
        var myPacket = new CommandPacket {
            Command = command,
            RequestId = Guid.NewGuid()
        };
        _pendingCommands.Add(myPacket);
    
        var buffer = Serialize(myPacket);
        socket.Send(buffer);
    }
    
    public void OnReceive(IAsynResult ar)
    {
        var bytesRead =  socket.EndRecieve(ar);
        _inStream.Write(_readBuffer, 0, bytesRead);
    
        if (GotCompletedPacket(_inStream))
        {
            var packet = Deserialize(_inStream);
            var waitingCommand = _pendingCommands.FirstOrDefault(p => p.RequestId == packet.RequestId);
    
            if (waitingCommand != null)
              //got a reply to the command.
        }
    
    }
