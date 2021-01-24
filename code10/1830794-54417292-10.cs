    public class SafeSocket {
            private const int BUFFER_SIZE = 1024;
            private WebSocket socket { get; set; }
            private SemaphoreSlim @lock = new SemaphoreSlim(1);
            public SafeSocket(WebSocket socket) {
                this.socket = socket;
            }
            public async Task<byte[]> ReadAsync() {
                byte[] buffer = ArrayPool<byte>.Shared.Rent(BUFFER_SIZE);
                await @lock.WaitAsync();
                try {
                    await this.socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                    return buffer;
                } catch (Exception) {
    
                    throw;
                } finally {
                    @lock.Release();
                }
            }
    
        }
        public class DispatcherMiddleware {
            private  List<Sender> senders;
            private Receiver receiver;
            private RequestDelegate next;
            public DispatcherMiddleware(RequestDelegate req, List<Sender> _senders, Receiver _receiver) {
                this.senders = _senders;
                this.receiver = _receiver;
                this.next = req;
            }
            public async Task Invoke(HttpContext context) {
                if (!context.WebSockets.IsWebSocketRequest) {
                    return;
                }
                await DispatchAsync(context.WebSockets);
            }
            public async Task DispatchAsync(WebSocketManager manager) {
    
                WebSocket socket = await manager.AcceptWebSocketAsync();
                SafeSocket commonSocket = new SafeSocket(socket);
                Task[] senderTasks = new Task[this.senders.Count];
                for (int senderIndex = 0; senderIndex < senderTasks.Length; senderIndex++) {
                    int index = senderIndex;// careful at index ! , make copy and use it inside closure !
                    senderTasks[senderIndex] = Task.Run(async () => {
                        await commonSocket.ReadAsync();
                    });
                }
            }
