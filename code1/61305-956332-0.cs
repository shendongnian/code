    static void Main(string[] args)
        {
            Dispatcher dp = new Dispatcher();
            DispatcherQueue dq = new DispatcherQueue("DQ", dp);
            Port<long> offsetPort = new Port<long>();
            Arbiter.Activate(dq, Arbiter.Receive<long>(true, offsetPort,
                new Handler<long>(Split)));
            FileStream fs = File.Open(file_path, FileMode.Open);
            long size = fs.Length;
            fs.Dispose();
            for (long i = 0; i < size; i += split_size)
            {
                offsetPort.Post(i);
            }
        }
        private static void Split(long offset)
        {
            FileStream reader = new FileStream(file_path, FileMode.Open, 
                FileAccess.Read);
            reader.Seek(offset, SeekOrigin.Begin);
            long toRead = 0;
            if (offset + split_size <= reader.Length)
                toRead = split_size;
            else
                toRead = reader.Length - offset;
            byte[] buff = new byte[toRead];
            reader.Read(buff, 0, (int)toRead);
            reader.Dispose();
            File.WriteAllBytes("c:\\out" + offset + ".txt", buff);
        }
