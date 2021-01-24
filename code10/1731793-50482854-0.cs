    private string[] CallSaleProvider(string YourParam1,string YourParam2)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://YourAddress");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization", Auth);
            using (var streamWriter = new
            StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    YourParam=Value, YourParam=value,YourParam=value
                });
                streamWriter.Write(json);
            }
            string result;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            string[] s = result.Split(',');
            for (int i = 0; i < s.Count(); ++i)
                s[i] = s[i].Substring(s[i].IndexOf(":") + 2, s[i].LastIndexOf('"') - s[i].IndexOf(":") - 2);
            
            httpResponse.Close();
            return s;
        }
 
