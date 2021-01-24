    public static void StartGet()
    {
        HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(VECO.VecoPriceURL));
    
        WebReq.Method = "GET";
    
        HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
    
        string jsonString;
        using (Stream stream = WebResp.GetResponseStream())
        {
            StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
            jsonString = reader.ReadToEnd();
        }
    
        var item = JsonConvert.DeserializeObject<RootObject>(jsonString);
        Console.WriteLine(item.veco.usd);
    }
