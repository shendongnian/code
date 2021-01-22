    using System;
    using System.IO;
    using System.Text;
    
    class Program
    {
    	static void
    	Main(string[] args)
    	{
    		string xml = "<xml><request>...[snipped for brevity]...</request></xml>";
    		using ( MemoryStream stream = new MemoryStream() )
    		{
    			using ( BinaryWriter writer = new BinaryWriter(stream) )
    			{
    				byte [] encodedXml = Encoding.UTF8.GetBytes(xml);
    				writer.Write(ToBigEndian(encodedXml.Length + 4));
    				writer.Write(encodedXml);
    			}
    			
    			byte [] request = stream.ToArray();
    			
    			//	now use request however you like
    		}
    	}
    	
    	static byte []
    	ToBigEndian(int value)
    	{
    		byte [] retval = BitConverter.GetBytes(value);
    		if ( BitConverter.IsLittleEndian )
    		{
    			Array.Reverse(retval);
    		}
    		return retval;
    	}
    }
