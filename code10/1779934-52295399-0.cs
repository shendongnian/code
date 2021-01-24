    /// <summary>
    /// this function loads the CookieContainer that contains the Session Cookies
    /// </summary>
    public static void LoadHTTPClient()
    {
        CookieJar = new CookieContainer();
        if (File.Exists(@"ClientSessionCookies.dat"))
        {
            // LOAD
            FileStream inStr = new FileStream(@"ClientSessionCookies.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            CookieJar = bf.Deserialize(inStr) as CookieContainer;
            inStr.Close();
        }
        var handler = new HttpClientHandler
        {
            CookieContainer = CookieJar,
            UseCookies = true,
        };
        Client = new HttpClient(handler);
    }
    /// <summary>
    /// this function saves the sessioncookies to file
    /// </summary>
    /// <param name="CookieJar"></param>
    public static void SaveHTTPClient(CookieContainer CookieJar)
    {
        // SAVE client Cookies
        FileStream stream = new FileStream(@"ClientSessionCookies.dat", FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, CookieJar);
        stream.Close();
    }
