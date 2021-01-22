    class Downloader
    {
        const int size = 4096 * 1024;
        ManualResetEvent done = new ManualResetEvent(false);
        Socket socket;
        Stream stream;
        void InternalWrite(IAsyncResult ar)
        {
            var read = socket.EndReceive(ar);
            if (read == size)
                InternalRead();
            stream.Write((byte[])ar.AsyncState, 0, read);
            if (read != size)
                done.Set();
        }
        void InternalRead()
        {
            var buffer = new byte[size];
            socket.BeginReceive(buffer, 0, size, System.Net.Sockets.SocketFlags.None, InternalWrite, buffer);
        }
        public bool Save(Socket socket, Stream stream)
        {
            this.socket = socket;
            this.stream = stream;
            InternalRead();
            return done.WaitOne();
        }
    }
    bool Save(System.Net.Sockets.Socket socket, string filename)
    {
        using (var stream = File.OpenWrite(filename))
        {
            var downloader = new Downloader();
            return downloader.Save(socket, stream);
        }
    }
