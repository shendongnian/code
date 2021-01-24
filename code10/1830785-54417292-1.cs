    public class DispatcherMiddleware{
        private Sender sender;
        private Receiver receiver;
        private RequestDelegate next;
       public Dispatcher(RequestDelegate req,Sender _sender,Receiver _receiver)
       {
        this.sender=_sender;
        this.receiver=_receiver;
        this.next=req;
       }
        public async Task Invoke(HttpContext context){
            if(!context.WebSockets.IsWebSocketRequest){
                return;
            }
            await DispatchAsync(context.WebSockets);
        }
        public async Task DispatchAsync(WebsocketManager manager){
             WebSocket socket=await manager.AcceptWebSocketAsync();
             Task t1=Task.Run(async()=>await this.sender.SendAsync(socket));
             Task t2=Task.Run(async()=>await this.receiver.ReceiveAsync(socket));
             await Task.WhenAll(t1,t2);
             
        }
    }
