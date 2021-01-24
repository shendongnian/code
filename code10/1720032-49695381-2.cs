    public class MainWindowViewModel
    {
        public Requester Requester { get; } = new Requester();
    
        public void RequestData() => Requester.RequestData();
    }
