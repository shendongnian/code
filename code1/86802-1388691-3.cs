    ... Start(....) {
        sync = socket.BeginReceive(.... MessageLengthReceived, null);
    }
    private void MessageLengthReceived(IAsyncResult sync) {
      var len = socket.EndReceive(sync);
      // ... set up buffer etc. for message receive
     sync = socket.BeginReceive(... MessageReceived, null);
    }
    private void MessageReceived(IAsyncResult sync) {
      var len = socket.EndReceive(sync);
      // ... process message
    }
