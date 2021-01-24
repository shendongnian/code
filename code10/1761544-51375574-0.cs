    using (var ws = new WebSocket ("ws://echo.websocket.org"))
    {
        ws.OnMessage += (sender, e) =>
            nf.Notify (
              new NotificationMessage {
                Summary = "WebSocket Message",
                Body = !e.IsPing ? e.Data : "Received a ping.",
                Icon = "notification-message-im"
              }
            );
        ws.Send (YOUR_MESSAGE);
    }
