    using System.Net;
    private string GetWorldIP()
    {
        String url = "http://bot.whatismyipaddress.com/";
        String result = null;
        try
        {
            WebClient client = new WebClient();
            result = client.DownloadString(url);
            return result;
        }
        catch (Exception ex) { return "127.0.0.1"; }
    }
