    public class Program
    {
    	public static string MyCustomEnconder(byte[] data)
    	{
    		string mapping = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvqwxyz!#$%&()*+-;<=>?@^_`{|}~',./:[]\\\"";
    		BigInteger base10 = new BigInteger(data);
    		string baseX;
    		int bse = mapping.Length;
    		var result = new Stack<char>();
    		do
    		{
    			result.Push(mapping[(int)(base10 % bse)]);
    			base10 /= bse;
    		}
    		while (base10 != 0);
    		baseX = new string (result.ToArray());
    		return baseX;
    	}
    
    	public static void Main()
    	{
    		// parse the address
    		IPAddress ip = IPAddress.Parse("192.168.0.1");
    		//iterate the byte[] and print each byte
    		foreach (byte i in ip.GetAddressBytes())
    		{
    			Console.Write(i.ToString("X2"));
    		}
    
    		Console.WriteLine();
    		Console.WriteLine(Convert.ToBase64String(ip.GetAddressBytes()));
    		Console.WriteLine(MyCustomEnconder(ip.GetAddressBytes()));
    	}
    }
