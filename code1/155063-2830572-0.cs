    class Client {
        Client() {
            this.OwningDispatcher = Dispatcher.CurrentDispatcher;
        }
        Dispatcher OwningDispatcher { get; private set; }
    }
