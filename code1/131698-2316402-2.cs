    using System; 
    using System.Net; 
    using System.Net.Sockets; 
    using System.Runtime.Serialization; 
    using System.Runtime.Serialization.Formatters.Binary; 
    
    class DataRcvr 
    { 
      public static void Main() 
      { 
       TcpListener server = new TcpListener(9050); 
       server.Start(); 
       TcpClient client = server.AcceptTcpClient(); 
       NetworkStream strm = client.GetStream(); 
       IFormatter formatter = new BinaryFormatter(); 
    
       Person p = (Person)formatter.Deserialize(strm); // you have to cast the deserialized object 
        
       Console.WriteLine("Hi, I'm "+p.FirstName+" "+p.LastName+" and I'm "+p.age+" years old!"); 
    
       strm.Close(); 
       client.Close(); 
       server.Stop(); 
      } 
    }
