    public async Task<IActionResult> Post()
    {
        if (!this.HttpContext.WebSockets.IsWebSocketRequest)
        {
            return this.BadRequest();
        }
        using (var webSocket = await this.HttpContext.WebSockets.AcceptWebSocketAsync())
        {
            using (var jsonRpc = new JsonRpc(new WebSocketMessageHandler(webSocket)))
            {
                jsonRpc.AddLocalRpcTarget(new SocketServer());
                jsonRpc.StartListening();
                await jsonRpc.Completion;
            }
        }
        return new EmptyResult();
    }
