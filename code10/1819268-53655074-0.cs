    public class CustomClass { }
    
    public interface IConn
    {
        CustomClass CC { get; set; } // or just "get;"
    }
    
    public class Conn : IConn
    {
        public CustomClass CC { get; set; } = new CustomClass();
    }
