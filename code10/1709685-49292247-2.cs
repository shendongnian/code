    public class StateObject
    {
    	public Socket Socket { get; set; }
    
    	public byte[] Buffer { get; } = new byte[1024];
    
    	public StateObject(Socket socket)
    	{
    		Socket = socket;
    	}
    }
