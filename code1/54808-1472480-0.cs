    internal interface IPort
    {
       void Connect(); 
       //Other members
    }
    
    internal class SerialPort : IPort
    {
       public void Connect() 
       {
          //Implementation
       }
    }
    
    public class DataRetriever
    {
       private IPort _port;
       public DataRetriever(IPort port)
       {
           _port = port;
       }
      
       public void ReadData()
       {
          _port.Connect();
       }
    }
