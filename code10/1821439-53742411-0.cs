    // Converts a long into an array of bytes with length 
    // eight.
    [System.Security.SecuritySafeCritical]  // auto-generated
    public unsafe static byte[] GetBytes(long value)
    {
    	Contract.Ensures(Contract.Result<byte[]>() != null);
    	Contract.Ensures(Contract.Result<byte[]>().Length == 8);
    
    	byte[] bytes = new byte[8];
    	fixed(byte* b = bytes)
    		*((long*)b) = value;
    	return bytes;
    }
