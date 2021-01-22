    private static void ReceiveCallback(IAsyncResult asyncResult )
    {
    	ClientInfo cInfo = (ClientInfo)asyncResult.AsyncState;
    	 
    	cInfo.BytesReceived += cInfo.Soket.EndReceive(asyncResult);
    	if (cInfo.RcvBuffer == null)
    	{
    		// First 2 byte is lenght
    		if (cInfo.BytesReceived >= 2)
    		{
    			//this calculation depends on format which your client use for lenght info
    			byte[] len = new byte[ 2 ] ;
    			len[0] = cInfo.LengthBuffer[1];
    			len[1] = cInfo.LengthBuffer[0];
    			UInt16 length = BitConverter.ToUInt16( len , 0);
    
    			// buffering and nulling is very important
    			cInfo.RcvBuffer = new byte[length];
    			cInfo.BytesReceived = 0;
    
    		}
    	}
    	else
    	{
    		if (cInfo.BytesReceived == cInfo.RcvBuffer.Length)
    		{
    			 //Put your code here, use bytes comes from  "cInfo.RcvBuffer"
    			 
    			 //Send Response but don't use async send , otherwise your code will not work ( RcvBuffer will be null prematurely and it will ruin your code)
    			 
    			int sendLenghts = cInfo.Soket.Send( sendBack, sendBack.Length, SocketFlags.None);
    
    			// buffering and nulling is very important
    			//Important , set RcvBuffer to null because code will decide to get data or 2 bte lenght according to RcvBuffer's value(null or initialized)
    			cInfo.RcvBuffer = null;
    			cInfo.BytesReceived = 0;
    		}
    	}
    	
    	ContinueReading(cInfo);
     }
     
    private static void ContinueReading(ClientInfo cInfo)
    {
    	try 
    	{
    		if (cInfo.RcvBuffer != null)
    		{
    			cInfo.Soket.BeginReceive(cInfo.RcvBuffer, cInfo.BytesReceived, cInfo.RcvBuffer.Length - cInfo.BytesReceived, SocketFlags.None, ReceiveCallback, cInfo);
    		}
    		else
    		{
    			cInfo.Soket.BeginReceive(cInfo.LengthBuffer, cInfo.BytesReceived, cInfo.LengthBuffer.Length - cInfo.BytesReceived, SocketFlags.None, ReceiveCallback, cInfo);
    		}
    	}
    	catch (SocketException se)
    	{
    		//Handle exception and  Close socket here, use your own code 
    		return;
    	}
    	catch (Exception ex)
    	{
    		//Handle exception and  Close socket here, use your own code 
    		return;
    	}
    }
    
    class ClientInfo
    {
    	private const int BUFSIZE = 1024 ; // Max size of buffer , depends on solution  
    	private const int BUFLENSIZE = 2; // lenght of lenght , depends on solution
    	public int BytesReceived = 0 ;
    	public byte[] RcvBuffer { get; set; }
    	public byte[] LengthBuffer { get; set; }
    
    	public Socket Soket { get; set; }
    
    	public ClientInfo(Socket clntSock)
    	{
    		Soket = clntSock;
    		RcvBuffer = null;
    		LengthBuffer = new byte[ BUFLENSIZE ];
    	}   
     
    }
