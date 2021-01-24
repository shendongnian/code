    public static string Base64EncodeIP(string ip)
    {
        UInt32 ipasint = BitConverter.ToUInt32(IPAddress.Parse(ip).GetAddressBytes(), 0);
        byte[] ipasbytes = BitConverter.GetBytes(ipasint);
        string encodedip = Convert.ToBase64String(ipasbytes);
        return encodedip.Replace("=", "");
    }
    public static string Base64DecodeIP(string encodedIP)
    {
        //re-add however much padding is needed, to make the length a multiple of 4
        if (encodedIP.Length % 4 != 0)
            encodedIP += new string('=', 4 - encodedIP.Length % 4);
        byte[] ipasbytes = Convert.FromBase64String(encodedIP);
        UInt32 ipasint = BitConverter.ToUInt32(ipasbytes, 0);
        return new IPAddress(BitConverter.GetBytes(ipasint)).ToString();
    }
