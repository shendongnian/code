        namespace YourProjectName.ChatHub {
            [HubName("ChatHub")]
            public class ChatHub : Hub {
                [HubMethodName("Sendchat")]
                public void Send(String Message,String Touser) {
                     Clients.Client(Touser).GotMessages(Message);//send messages to specific user
                   //Clients.All.GotMessages(Message); //seln messages to all user
                    String CName = Message;
                }
        
                [HubMethodName("hubconnect")]
                public void Get_Connect(String Name) {
                    Clients.All.GotMessages(Name +" Connected  Connection Id is "+ this.Context.ConnectionId);
                    String CName = Name;
                }
        
                public override System.Threading.Tasks.Task OnConnected() {
                    return base.OnConnected();
                }
        
                public override System.Threading.Tasks.Task OnReconnected() {
                    return base.OnReconnected();
                }
        
                public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled) {
                    return base.OnDisconnected(stopCalled);
                }
            }
        }
