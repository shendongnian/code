    public void Connect()
    {
        try
        {
            request = (HttpWebRequest)WebRequest.Create("Http://192.168.0.2/index.html");
            request.Credentials = new NetworkCredential(UserName,Password);
            request.Method = "GET";
            response = (HttpWebResponse)request.GetResponse();
            WebHeaderCollection headers = response.Headers;
            Cookie = headers["Set-Cookie"];//get cookie
            GetImage(null);
        }
        catch (Exception ex)
        {
            BitmapObject bitmap = new BitmapObject(Properties.Resources.Off,DateTime.Now);
            bitmap.Error = ex.Message;
            onImageReady(bitmap);
        }
    }
    private Stream GetStream()
    {
        Stream s = null;
        try
        {
            request = (HttpWebRequest)WebRequest.Create("http://192.168.0.2/liveimg.cgi");
            if (!Anonimous)
                request.Credentials = new NetworkCredential(UserName, Password);
            request.Method = "GET";
            request.KeepAlive = KeepAlive;
            request.Headers.Add(HttpRequestHeader.Cookie, Cookie);
            response = (HttpWebResponse)request.GetResponse();
            s = response.GetResponseStream();
        }
        catch (Exception ex)
        {
            BitmapObject bitmap = new BitmapObject(Properties.Resources.Off,DateTime.Now);
            bitmap.Error = ex.Message;
            onImageReady(bitmap);
        }
        return s;
    }
    public void GetImage(Object o)
    {
        BitmapObject bitmap = null;
        stream = GetStream();
        DateTime CurrTime = DateTime.Now;
        try
        {
            bitmap = new BitmapObject(new Bitmap(stream),CurrTime);
            if (timer == null)//System.Threading.Timer
                timer = new Timer(new TimerCallback(GetImage), null, 200, 200);
        }
        catch (Exception ex)
        {
            bitmap = new BitmapObject(Properties.Resources.Off, CurrTime);
            bitmap.Error = ex.Message;
        }
        finally
        {
            stream.Flush();
            stream.Close();
        }
        onImageReady(bitmap);
    }
