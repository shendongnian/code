    public class Reload
    {
    }
    public class Request
    {
        public string User { get; set; }
        public DateTime Time { get; set; }
        // and other logics about requests
    }
    public interface IFactory
    {
        Reload Create(Request request);
    }
