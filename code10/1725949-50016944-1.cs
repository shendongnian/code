    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;
    using Microsoft.Web.WebSockets;
    
    public class SomeController : ApiController
    {
        // Has to be called something starting with "Get"
        public HttpResponseMessage Get()
        {
            HttpContext.Current.AcceptWebSocketRequest(new SomeWebSocketHandler());
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
        }
    
        class SomeWebSocketHandler : WebSocketHandler
        {
            public SomeWebSocketHandler() { SetupNotifier(); }
            protected void SetupNotifier()
            {
                // Call a method to handle whichever change you want to broadcast
                var messageToBroadcast = "Hello world";
                broadcast(messageToBroadcast);
            }
    
            private static WebSocketCollection _someClients = new WebSocketCollection();
    
            public override void OnOpen()
            {
                _someClients.Add(this);
            }
    
            public override void OnMessage(string message)
            {
    
            }
    
            private void broadcast(string message)
            {
                _someClients.Broadcast(msg);
                SetupNotifier();
            }
        }
    
    }
