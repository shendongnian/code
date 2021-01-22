    public sealed class ServerOperationHandler : DefaultMessageHandler<ServerOperationCode> {
        public ServerOperationHandler() {
            this.RegisterMessageHandler(ServerOperationCode.LoginResponse, this.HandleLoginResponse);
            this.RegisterMessageHandler(ServerOperationCode.SelectionResponse, this.HandleSelectionResponse);
        }
        private void HandleLoginResponse(IMessage<ServerOperationCode> message, IConnection connection) {
            //TODO
        }
        private void HandleSelectionResponse(IMessage<ServerOperationCode> message, IConnection connection) {
            //TODO
        }
    }
