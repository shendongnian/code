      public string GetICDCode(string ICDCode)
        {
            DiagnosisModel model = new DiagnosisModel();
            String postURL = string.Format("http://icd10api.com/?code={0}&desc=short&r=json", ICDCode);
            WebRequest request = WebRequest.Create(postURL);
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";
            var response = (HttpWebResponse)request.GetResponse();
            string jsonText;
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                jsonText = sr.ReadToEnd();
            }
            return jsonText;
        }
