        using System.Linq;
        using System.Net;
        using System.Web;
        using System.Web.Script.Serialization;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        using Facebook;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Linq;    
        
            public class AccessUser
            {
                public string access_token { get; set; }
                public string token_type { get; set; }
                public string expires_in { get; set; }
            }
        
            private void CheckAuthorization()
                {
                    string app_id = "**************";
                    string app_secret = "************************";
        
                    if (Request["code"] == null)
                    {
                        var redirectUrl = string.Format("https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}", app_id, Request.Url.AbsoluteUri);
                        Response.Redirect(redirectUrl);
                    }
                    else
                    {
                        AccessUser au = new AccessUser();
        
                        string url = string.Format("https://graph.facebook.com/v3.2/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}", app_id, Request.Url.AbsoluteUri, app_secret, Request["code"].ToString());
        
                        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
        
                        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                        {
                            StreamReader reader = new StreamReader(response.GetResponseStream());
                            string vals = reader.ReadToEnd();
                            au = JsonConvert.DeserializeObject<AccessUser>(vals);
                            string token = au.access_token;
        
                        }
                    }
                }
