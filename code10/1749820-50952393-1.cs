    static void Main(string[] args)
    {
        ...
    	serial.DiscardInBuffer(); // Clear any remaining rx bytes
    	serial.Write(ReadHoldingRegister(2, 1024, 16), 0, 8);
    
    	Queue<byte> response = GetResponse(serial, 5);
    
    	if (response.Count > 0)
    	{
    	    // Process Response
    	    // 1) check the CRC
    	    // 2) if crc ok, check if it is an exception response
    	    // 3) if not an exception check that it "matches" the request
    	    // ...
    	}
    
        ...
    }
