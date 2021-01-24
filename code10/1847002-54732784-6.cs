    public interface IWebSocket {
        event EventHandler OnOpen;
        void ConnectAsync();
        //... other members
    }
