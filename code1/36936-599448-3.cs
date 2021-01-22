    static void Main(string[] args)
    {
        Thread t = new Thread(
            delegate() {
                List<Packet> packets;
                while (true) {
                    PacketReceived.WaitOne();
                    PacketReceived.Reset();
                    lock (SyncRoot) {
                        packets = PacketList;
                        PacketList = new List<Packet>();
                    }
                    foreach (Packet packet in packets) {
                        // Process the packet
                    }
                }
            }
        );
        t.IsBackground = true;
        t.Name = "Data Processing Thread";
        t.Start();
    }
