    using Newtonsoft.Json;
    using System.Net.Sockets;
    
    class A
    { 
        public TcpClient TcpClient { get; set; } = new TcpClient();
    }
    
    var a = new A();
    
    JsonConvert.SerializeObject(a);
