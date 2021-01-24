            var baseurl = "https://example.com/api/upload/123";
            var rqst = (HttpWebRequest)WebRequest.Create(baseurl);
            rqst.Method = "PUT";
            rqst.Accept = "application/json";
            var authInfo = "authtoken";
            rqst.Headers["Authorization"] = "Token  " + authInfo;
            rqst.UserAgent = "curl/7.37.0";
            rqst.ContentType = "application/json; charset=utf-8";
            using (var streamWriter = new StreamWriter(rqst.GetRequestStream()))
            {
                streamWriter.Write(GetJsonData());
            }
            try
            {
                var resp = rqst.GetResponse();
                using (var sr = new StreamReader(resp.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    var txt = sr.ReadToEnd();
                    textBox1.Text = txt;
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
