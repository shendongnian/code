    public static void Main()
	{
        System.Net.IPAddress someIP = System.Net.IPAddress.Parse("192.168.1.23");
        System.Net.IPAddress someMASK = System.Net.IPAddress.Parse("255.255.255.128");
        long ipL = IPtoLong(someIP);
        long maskL = IPtoLong(someMASK);
        // Convert  Mask to CIDR(1-30)
        long oneBit = 0x80000000L;
        int CIDR = 0;
        for (int x = 31; x >= 0; x += -1)
        {
            if ((maskL & oneBit) == oneBit)
                CIDR += 1;
            else
                break;
            oneBit = oneBit >> 1;
        }
        string answer = LongToIp(ipL & maskL) + "/" + CIDR.ToString();
		
		Console.Out.WriteLine("woah woah we woah " + answer);
	}
	
	public static long IPtoLong(System.Net.IPAddress theIP) // convert IP to number
	{
		byte[] IPb = theIP.GetAddressBytes(); // get the octets
		long addr = 0; // accumulator for address
		for (int x = 0; x <= 3; x++) {
			addr |=  (System.Convert.ToInt64(IPb[x]) << (3 - x) * 8);
		}
		return addr;
	}
    public static string LongToIp(long theIP) // convert number back to IP
    {
        byte[] IPb = new byte[4]; // 4 octets
        string addr = ""; // accumulator for address
        long mask8 = MaskFromCidr(8); // create eight bit mask
        for (var x = 0; x <= 3; x++) // get the octets
        {
            IPb[x] = System.Convert.ToByte((theIP & mask8) >> ((3 - x) * 8));
            mask8 = mask8 >> 8;
            addr += IPb[x].ToString() + "."; // add current octet to string
        }
        return addr.TrimEnd('.');
    }
    private static long MaskFromCidr(int CIDR)
    {
        return  System.Convert.ToInt64(Math.Pow(2, ((32 - CIDR))) - 1) ^ 4294967295L;
    }
