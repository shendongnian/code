    void Send(WebSocket webSocket, byte[] buffer, Guid guid)
    {
      x.GetOrAdd(guid, new ValueTuple<System.Byte[], WebSocketReceiveResult>(buffer, null));
      await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None)
    }
    void Receive(WebSocket webSocket, Guid guid)
    {
      var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
      x[guid].Item2 = result;
    }
