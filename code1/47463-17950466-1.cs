    using System.Net;
    public static string GetIpAddress()  // Get IP Address
    {
        string ip = "";     
        IPHostEntry ipEntry = Dns.GetHostEntry(GetCompCode());
        IPAddress[] addr = ipEntry.AddressList;
        ip = addr[2].ToString();
        return ip;
    }
    public static string GetCompCode()  // Get Computer Name
    {   
        string strHostName = "";
        strHostName = Dns.GetHostName();
        return strHostName;
    }
