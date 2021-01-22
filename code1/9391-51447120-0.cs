    var result = false;
    try {
        using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)) {
            var asyncResult = socket.BeginConnect(yourUri.AbsoluteUri, 80, null, null);
            result = asyncResult.AsyncWaitHandle.WaitOne(100, true);
            socket.Close();
        }
    }
    catch { }
    return result;
