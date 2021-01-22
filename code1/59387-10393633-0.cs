    public static bool UrlIsValid(string url)
    {
        bool br = false;
        try {
            IPHostEntry ipHost = Dns.Resolve(url);
            br = true;
        }
        catch (SocketException se) {
            br = false;
        }
        return br;
    }
