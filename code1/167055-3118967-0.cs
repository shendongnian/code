    static void StreamToServer(TcpClient client, Command obj) {
      using (NetworkStream ns = client.GetStream()) {
        using (MemoryStream ms = new MemoryStream()) {
          BinaryFormatter formatter = new BinaryFormatter();
          formatter.Serialize(ms, obj);
          byte[] buf = ms.ToArray();
          ns.Write(buf, 0, buf.Length);
        }
      }
    }
