    public class YourHubName : Hub<IClient>
    {
        public void MethodCanBeCalledFromClient(string message)
        {
            Clients.All.MethodCanBeCalledFromServer(message);
        }
    }
    public interface IClient
    {
        void MethodCanBeCalledFromServer(string message);
    }
