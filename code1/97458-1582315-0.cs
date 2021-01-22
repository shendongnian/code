    class State
    {
        public Stream Stream { get; set; }
        public byte[] Buffer { get; set; }
    }
    class Program
    {
        private const int ChunkSize = 1024;
        static void Main(string[] args)
        {
            var stream = new FileStream("test.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var state = new State { Stream = stream, Buffer = new byte[ChunkSize] };
            var ar = stream.BeginRead(state.Buffer, 0, state.Buffer.Length, Callback, state);
            while (!ar.IsCompleted)
            {
                Thread.Sleep(10);
            }
        }
        static void Callback(IAsyncResult ar)
        {
            var state = (State)ar.AsyncState;
            var bytesRead = state.Stream.EndRead(ar);
            if (bytesRead > 0)
            {
                byte[] buffer = new byte[bytesRead];
                Buffer.BlockCopy(state.Buffer, 0, buffer, 0, bytesRead);
                state.Stream.BeginRead(state.Buffer, 0, state.Buffer.Length, Callback, state);
                // Do something with the received buffer.
                Console.Write(Encoding.UTF8.GetString(buffer));
            }
            else
            {
                // reached the end of the stream
                state.Stream.Dispose();
            }
        }
    }
