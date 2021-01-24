    public class CustomClass { }
    
    public interface IConn
    {
        CustomClass CC { get; set; } // or just "get;"
    }
    
    public class Conn : IConn
    {
        // I have changed this to a property.
        public CustomClass CC { get; set; } = new CustomClass();
    }
