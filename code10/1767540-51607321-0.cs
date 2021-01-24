    static NetworkStream Stream;
    static MemoryStream Data;
    static byte[] AWNSER = new byte[256];
    
    static void Main(string[] args)
    {
    	TcpListener listen = new TcpListener(IPAddress.Any, 123);
    	listen.Start();
    	Stream = listen.AcceptTcpClient().GetStream();
    	Data = new MemoryStream();
    	Stream.BeginRead(AWNSER, 0, AWNSER.Length, HNDLR, null);
    	while (true)
    	{
    		var str = Console.ReadLine();
    		byte[] MESSAGE = Encoding.UTF8.GetBytes(str + "&& cd\n");
    		Stream.Write(MESSAGE, 0, MESSAGE.Length);
    	}
    }
    
    static void HNDLR(IAsyncResult a)
    {
    	int numRead = Stream.EndRead(a);
    	if (numRead == 0) return;
    
    	Data.Seek(0, SeekOrigin.End);
    	Data.Write(AWNSER, 0, numRead);
    
    	byte[] bytes = Data.GetBuffer();
    	int idx = 0;
    	int size = (int) Data.Length;
    
    	while (idx < size)
    	{
    		int found = Array.FindIndex(bytes, idx, size - idx, b => b == 0x0A);
    		if (found == -1) break;
    		Console.WriteLine(Encoding.UTF8.GetString(AWNSER, idx, found-idx);
    		idx = found + 1;
    	}
    
    	if (idx > 0)
    	{
    		Buffer.BlockCopy(bytes, idx, bytes, 0, size - idx);
    		Data.SetLength(size - idx);
    	}
    
    	Stream.BeginRead(AWNSER, 0, AWNSER.Length, HNDLR, null);
    }
