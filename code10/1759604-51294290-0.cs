    public static class StreamExtension
    {
    	public static IEnumerable<long> ScanAOB(this Stream stream, params byte[] aob)
    	{
    		long position;
    		byte[] buffer = new byte[aob.Length - 1];
    
    		while ((position = stream.Position) < stream.Length)
    		{
    			if (stream.ReadByte() != aob[0]) continue;
    
    			stream.Read(buffer, 0, aob.Length - 1);
    			if (buffer.SequenceEqual(aob.Skip(1)))
    			{
    				yield return position;
    			}
    		}
    	}
    	
    	public static IEnumerable<long> ScanAOB(this Stream stream, params byte?[] aob)
    	{
    		long position;
    		byte[] buffer = new byte[aob.Length - 1];
    
    		while ((position = stream.Position) < stream.Length)
    		{
    			if (stream.ReadByte() != aob[0]) continue;
    
    			stream.Read(buffer, 0, aob.Length - 1);
    			if (buffer.Cast<byte?>().SequenceEqual(aob.Skip(1), new AobComparer()))
    			{
    				yield return position;
    			}
    		}
    	}
    	
    	private class AobComparer : IEqualityComparer<byte?>
    	{
    		public bool Equals(byte? x, byte? y) => x == null || y == null || x == y;
    		public int GetHashCode(byte? obj) => obj?.GetHashCode() ?? 0;
    	}
    }
