    CookieContainer cookieContainer = new CookieContainer();
    
    void LoadCookiesFromFile(string path)
    {
        SetCookies(cookieContainer, File.ReadAllText(path));
    }
    
    void SaveCookiesToFile(string path)
    {
        File.WriteAllText(path, GetCookies(cookieContainer));
    }
    
    string GetCookies(CookieContainer cookieContainer)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            new BinaryFormatter().Serialize(stream, cookieContainer);
            var bytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(bytes, 0, bytes.Length);
            return Convert.ToBase64String(bytes);
        }
    }
    
    void SetCookies(CookieContainer cookieContainer, string cookieText)
    {
        try
        {
            var bytes = Convert.FromBase64String(cookieText);
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                cookieContainer = (CookieContainer)new BinaryFormatter().Deserialize(stream);
            }
        }
        catch
        {
            //Ignore if the string is not valid.
        }
    }
