    class PublicState {
        internal readonly BufferBlock<Message> OutgoingMessageQueue = new BufferBlock<Message>();
        internal readonly TaskCompletionSource<Object> ConnectedTcs = new TaskCompletionSource<Object>();
        public void EnqueueMessage(Message message) {
            this.OutgoingMessageQueue.Post(message);
        }
    }
    static async Task RunAsync(IPEndPoint endPoint, PublicState state) {
        using (TcpClient tcp = new TcpClient()) {
            await tcp.ConnectAsync(endPoint.Address, endPoint.Port).ConfigureAwait(false);
            Byte[] reusableBuffer = new Byte[4096];
            using (NetworkStream ns = tcp.GetStream()) {
                state.ConnectedTcs.SetResult(null);
                Task<Int32> nsReadTask = null;
                Task<Message> newMessageTask = null;
                while (tcp.Connected) {
                    // Wait for new data to arrive from remote host or for new messages to send:
                    if (nsReadTask == null)
                        nsReadTask = ns.ReadAsync(reusableBuffer, 0, 0);
                    if (newMessageTask == null)
                        newMessageTask = state.OutgoingMessageQueue.ReceiveAsync();
                    var completed = await Task.WhenAny(nsReadTask, newMessageTask).ConfigureAwait(false);
                    if (completed == newMessageTask) {
                        var result = await newMessageTask;
                        // do stuff
                        newMessageTask = null;
                    }
                    else {
                        var bytesRead = await nsReadTask;
                        nsReadTask = null;
                    }
                }
            }
        }
    }
