            public string[] GetResponseWebAPI(string strPostData, string strUrl)
        {
            string[] arrReturn = new string[3];
            ServicePointManager.ServerCertificateValidationCallback =
                (sender, certificate, chain, sslPolicyErrors) => true;
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };
            using (var client = new HttpClient(handler))
            using (var content =
                new FormUrlEncodedContent(new[] {new KeyValuePair<string, string>("Request", strPostData)}))
            {
                client.Timeout = TimeSpan.FromSeconds(25);
                var response = client.PostAsync(strUrl, content).GetAwaiter().GetResult();
                arrReturn[0] = response.Headers.GetValues("Statuscode").FirstOrDefault();
                arrReturn[1] = response.Headers.GetValues("Statusmessage").FirstOrDefault();
                arrReturn[2] = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            return arrReturn;
        }
