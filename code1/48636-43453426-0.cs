     static public bool CheckExist(string url)
    {
        HttpWebRequest wreq = null;
        HttpWebResponse wresp = null;
        bool ret = false;
    try
    {
        wreq = (HttpWebRequest)WebRequest.Create(url);
        wreq.Credentials = CredentialCache.DefaultCredentials;
        wreq.Proxy=null;
        wreq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:2.0) Gecko/20100101 Firefox/4.0";
        wreq.KeepAlive = true;
        wreq.Method = "HEAD";
        wresp = (HttpWebResponse)wreq.GetResponse();
        ret = true;
    }
    catch (System.Net.WebException)
    {
    }
    finally
    {
        if (wresp != null)
            wresp.Close();
    }
    return ret;
}
