    using System;
    using System.IO;
    using System.Net;
    using System.Web.Http;
    namespace MyMVCApplication.Controllers
    {
        public class TestConnectionController : ApiController
        {
            public string Get()
            {
                var url = new Uri("https://tlstest.paypal.com/");
                var request = (HttpWebRequest) WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                var response = request.GetResponse().GetResponseStream();
                if (response != null)
                {
                    string output;
                    using (var reader = new StreamReader(response))
                    {
                        output = reader.ReadToEnd();
                    }
                    return output;
                }
                return null;
            }
        }
    }
