    ConcurrentQueue<byte[]> pkts = new ConcurrentQueue<byte[]>();
    //IN THE RECEIVER THREAD...
    void ProductDefinitionReceiver()
    {
        while (!secDefsComplete)
        {
            byte[] data = new byte[1000];
            s.Receive(data);
            pkts.Enqueue(data);
        }
    }
    //IN A SEPARATE THREAD:
    public void processPacketQueue()
    {
        int dumped = 0;
        byte[] pkt;
        while (!secDefsComplete)
        {
            while (pkts.TryDequeue(out pkt))
            {
                if (!secDefsComplete)
                {
                    //processPkt includes the parsing and inserting the secDef object into the dictionary.
                    processPkt(pkt);
                }
                else
                {
                    dumped++;
                }
            }
        }
        Console.WriteLine("Dumped: " + dumped);
    }
