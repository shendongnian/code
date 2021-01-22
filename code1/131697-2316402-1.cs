    using System; 
    using System.Net; 
    using System.Net.Sockets; 
    using System.Runtime.Serialization; 
    using System.Runtime.Serialization.Formatters.Binary; 
    
    class DataSender 
    { 
      public static void Main() 
      { 
       Person p=new Person("Tyler","Durden",30); // create my serializable object 
       string serverIp="192.168.0.1"; 
    
       TcpClient client = new TcpClient(serverIp, 9050); // have my connection established with a Tcp Server 
    
       IFormatter formatter = new BinaryFormatter(); // the formatter that will serialize my object on my stream 
    
       NetworkStream strm = client.GetStream(); // the stream 
       formatter.Serialize(strm, p); // the serialization process 
    
       strm.Close(); 
       client.Close(); 
      } 
    } 
