    public static ManualResetEvent PacketReceived = new ManualResetEvent(false);
    public static List<Packet> PacketList = new List<Packet>();
    public static object SyncRoot = new object();
    public static void ReceiveCallback(IAsyncResult ar)
    {
        try {
            StateObject so = (StateObject)ar.AsyncState;
            int read = so.WorkSocket.EndReceive(ar);
            if (read > 0) {
                Packet packet = new Packet(DateTime.Now, so.Buffer, read);
                lock (SyncRoot) {
                    PacketList.Add(packet);
                }
                PacketReceived.Set();
            }
            so.WorkSocket.BeginReceive(so.Buffer, 0, so.Buffer.Length, 0, ReceiveCallback, so);
        } catch (ObjectDisposedException) {
            // Handle the socket being closed with an async receive pending
        } catch (Exception e) {
            // Handle all other exceptions
        }
    }
