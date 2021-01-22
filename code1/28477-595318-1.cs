        using System; 
        using System.Web;
        using System.Net; 
        using System.IO;
        using System.Web.UI;
        using System.Web.UI.WebControls; 
    
    namespace Foo
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
     
    
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("http://sso.bhmobile.ba/sso/login"); 
                req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705;)"; 
                req.Method = "POST";
                req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                req.Headers.Add("Accept-Language: en-us,en;q=0.5");
                req.Headers.Add("Accept-Encoding: gzip,deflate");
                req.Headers.Add("Accept-Charset: ISO-8859-1,utf-8;q=0.7,*;q=0.7");
                req.KeepAlive = true;
                req.Headers.Add("Keep-Alive: 300");
                req.Referer ="http://sso.bhmobile.ba/sso/login";
    
                req.ContentType = "application/x-www-form-urlencoded"; 
    
                String Username = "username";
                String PassWord = "Password";
    
                StreamWriter sw = new StreamWriter(req.GetRequestStream());
                sw.Write("application=portal&url=http%3A%2F%2Fwww.bhmobile.ba%2Fportal%2Fredirect%3Bjsessionid%3D1C568AAA1FB8B5C757CF5F68BE6ECE65%3Ftype%3Dssologin%26url%3D%2Fportal%2Fshow%3Bjsessionid%3D1C568AAA1FB8B5C757CF5F68BE6ECE65%3Fidc%3D1023278&realm=sso&userid=" + Username + "&password=" + password + "&x=16&y=11");
                sw.Close();
    
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
     
                 
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string tmp = reader.ReadToEnd();
    
                foreach (Cookie cook in response.Cookies)
                {
                    tmp += "\n" + cook.Name + ": " + cook.Value;
                }
    
    
                Response.Write(tmp);
                Response.End();
     
            }
        }
    }
