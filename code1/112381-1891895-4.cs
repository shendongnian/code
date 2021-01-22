    object locker = new object();
    using (StreamWriter result = new StreamWriter("result.txt"))
    {
        StreamReader file1 = new StreamReader("file1.txt");
        StreamReader file2 = new StreamReader("file2.txt");
        StreamReader file3 = new StreamReader("file3.txt");
        const int SOME_MAGICAL_NUMBER = 102400; // 100k?
        Queue<string> packets = new Queue<string>();
        StringBuilder buffer = new StringBuilder();
        Thread writer = new Thread(new ThreadStart(() =>
        {
            string packet = null;
            while (true)
            {
                Monitor.Wait(locker);
                lock (locker)
                {
                    packet = packets.Dequeue();
                }
                if (packet == null) return;
                result.Write(packet);
            }
        }));
        writer.Start();
        while (!file1.EndOfStream || !file2.EndOfStream || !file3.EndOfStream)
        {
            buffer.Append(file1.ReadLine() ?? "");
            buffer.Append(file2.ReadLine() ?? "");
            buffer.AppendLine(file3.ReadLine() ?? "");
            if (buffer.Length > SOME_MAGICAL_NUMBER)
            {
                lock (locker)
                {
                    packets.Enqueue(buffer.ToString());
                    buffer.Length = 0;
                    Monitor.PulseAll(locker);
                }
            }
        }
        lock (locker)
        {
            packets.Enqueue(buffer.ToString());
            packets.Enqueue(null); // done
            Monitor.PulseAll(locker);
        }
        writer.Join();
    }
