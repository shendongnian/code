private string GetHtml(string url)
{
    HttpWebRequest web = (HttpWebRequest)WebRequest.Create(url);
    web.Method = "GET";
    CookieContainer cookieJar = new CookieContainer();
    web.CookieContainer = cookieJar;
    using (WebResponse resp = web.GetResponse())
    {
        using (Stream istrm = resp.GetResponseStream())
        {
            using (StreamReader sr = new StreamReader(istrm))
            {
                string html = sr.ReadToEnd();
                sr.Close();
                resp.Close();
                return html;
            }
        }
    }
}
