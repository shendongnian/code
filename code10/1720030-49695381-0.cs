    public class Requester
    {
        public event Action DataRequested;
    
        public object Data { get; set; }
    
        public void RequestData() => DataRequested?.Invoke();
    }
