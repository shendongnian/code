    public static IPAddress IncrementIP(IPAddress addr)
    {
        byte[] ip = addr.GetAddressBytes();
        ip[3]++;
        if (ip[3] == 0) {
            ip[2]++;
            if (ip[2] == 0) {
                ip[1]++;
                if (ip[1] == 0)
                    ip[0]++;
            }
        }
        return new IPAddress(ip);
    }
