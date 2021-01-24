    public static string ImageToBase64()
    {
        var path = System.Web.HttpContext.Current.Server.MapPath(@"~\imgs\testpic.PNG");
        Byte[] bytes = File.ReadAllBytes(path);
        string base64String = Convert.ToBase64String(bytes);
    
        return "data:image/png;base64," + base64String;
    }
