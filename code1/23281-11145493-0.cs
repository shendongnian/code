    public class Internal
    {
        internal Internal() { }
    }
    public interface IAM
    {
        int ID { get; set; }
        void Save(Internal access);
    }
    
