    public static class BitEndianConverter
    {
    	public static byte[] GetBytes(bool value, bool littleEndian)
    	{
    		return ReverseAsNeeded(BitConverter.GetBytes(value), littleEndian);
    	}
    
    	public static byte[] GetBytes(char value, bool littleEndian)
    	{
    		return ReverseAsNeeded(BitConverter.GetBytes(value), littleEndian);
    	}
    	public static byte[] GetBytes(double value, bool littleEndian)
    	{
    		return ReverseAsNeeded(BitConverter.GetBytes(value), littleEndian);
    	}
    	public static byte[] GetBytes(float value, bool littleEndian)
    	{
    		return ReverseAsNeeded(BitConverter.GetBytes(value), littleEndian);
    	}
    	public static byte[] GetBytes(int value, bool littleEndian)
    	{
    		return ReverseAsNeeded(BitConverter.GetBytes(value), littleEndian);
    	}
    	public static byte[] GetBytes(long value, bool littleEndian)
    	{
    		return ReverseAsNeeded(BitConverter.GetBytes(value), littleEndian);
    	}
    	public static byte[] GetBytes(short value, bool littleEndian)
    	{
    		return ReverseAsNeeded(BitConverter.GetBytes(value), littleEndian);
    	}
    	public static byte[] GetBytes(uint value, bool littleEndian)
    	{
    		return ReverseAsNeeded(BitConverter.GetBytes(value), littleEndian);
    	}
    	public static byte[] GetBytes(ulong value, bool littleEndian)
    	{
    		return ReverseAsNeeded(BitConverter.GetBytes(value), littleEndian);
    	}
    	public static byte[] GetBytes(ushort value, bool littleEndian)
    	{
    		return ReverseAsNeeded(BitConverter.GetBytes(value), littleEndian);
    	}
    
    	private static byte[] ReverseAsNeeded(byte[] bytes, bool wantsLittleEndian)
    	{
    		if (wantsLittleEndian == BitConverter.IsLittleEndian)
    			return bytes;
    		else
    			return (byte[])bytes.Reverse().ToArray();
    	}
    }
