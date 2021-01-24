    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    
    namespace ApisCallTest
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            private static readonly HttpClient client = new HttpClient();
            public string access_token;
            protected void Page_Load(object sender, EventArgs e)
            {
                var values = new Dictionary<string, string>
                {
                   { "client_id", "REPLACE_ME" },
                   { "client_secret", "REPLACE_ME" },
                   { "refresh_token", "REPLACE_ME" },
                   { "grant_type", "refresh_token" }
                };
    
                var content = new FormUrlEncodedContent(values);
                var response = client.PostAsync("https://www.googleapis.com/oauth2/v4/token", content);
                string json = response.Result.Content.ReadAsStringAsync().Result;
                dynamic obj = JObject.Parse(json);
                access_token = obj.access_token;
            }
        }
    }
