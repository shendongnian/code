    public class Conn : IConn
    {
        public CustomClass CC = new CustomClass();
        CustomClass IConn.CC() => new CustomClass();
    }
