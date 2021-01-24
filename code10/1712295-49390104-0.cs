    public interface IHub
    {
        Task Send(string data);
        event Action<string> OnBroadcastAction;
    }
