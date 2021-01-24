    public interface IA
    {
        public bool A { get; set; }
    }
    
    public interface IB
    {
        public bool B { get; set; }
    }
    
    public class Settings: IA, IB
    {
        public bool A { get; set; }
        public bool B { get; set; }
    }
