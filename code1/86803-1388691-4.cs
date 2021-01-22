    private async Task<Message> ReceiveAMessage() {
      var prefix = new byte[Message.PrefixLength];
    
      var revcLen = await Task.Factory.FromAsync(
                             (cb, s) => clientSocket.BeginReceive(prefix, 0, prefix.Length, SocketFlags.None, cb, s),
                             ias => clientSocket.EndReceive(ias),
                             null);
      if (revcLen != prefix.Length) { throw new ApplicationException("Failed to receive prefix"); }
      
      int contentLength = Message.GetLengthFromPrefix(prefix);
      var content = new byte[contentLength];
      
      revcLen = await Task.Factory.FromAsync(
                             (cb, s) => clientSocket.BeginReceive(content, 0, content.Length, SocketFlags.None, cb, s),
                             ias => clientSocket.EndReceive(ias),
                             null);
      if (revcLen != content.Length) { throw new ApplicationException("Failed to receive content"); }
      
      return new Message(content);
    }
