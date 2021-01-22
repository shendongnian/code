    static Command ReadStream(TcpListener listener) {
      Command obj = null;
      using (TcpClient client = listener.AcceptTcpClient()) { // waits for data
        using (NetworkStream ns = client.GetStream()) {
          byte[] buf = new byte[client.ReceiveBufferSize];
          int len = ns.Read(buf, 0, buf.Length);
          using (MemoryStream ms = new MemoryStream(buf, 0, len)) {
            BinaryFormatter formatter = new BinaryFormatter();
            obj = formatter.Deserialize(ms) as Command;
          }
        }
      }
      return obj;
    }
