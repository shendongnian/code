    public class StreamWatcher
    {
        private readonly Stream stream;
        private byte[] sizeBuffer = new byte[2];
        public StreamWatcher(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            this.stream = stream;
        }
        protected void OnMessageAvailable(MessageAvailableEventArgs e)
        {
            var handler = MessageAvailable;
            if (handler != null)
                handler(this, e);
        }
        protected void WatchNext()
        {
            stream.BeginRead(sizeBuffer, 0, 2, new AsyncCallback(ReadCallback),
                null);
        }
        private void ReadCallback(IAsyncResult ar)
        {
            int bytesRead = stream.EndRead(ar);
            if (bytesRead != 2)
                throw new InvalidOperationException("Invalid message header.");
            int messageSize = sizeBuffer[1] << 8 + sizeBuffer[0];
            WatchNext();
            OnMessageAvailable(new MessageAvailableEventArgs(messageSize));
        }
        public event MessageAvailableEventHandler MessageAvailable;
    }
