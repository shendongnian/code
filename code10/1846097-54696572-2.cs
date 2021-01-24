    System.Net.WebRequest webRequest = System.Net.WebRequest.Create("https://directline.botframework.com/v3/directline/conversations");
            webRequest.Method = "POST";
            string content = " ";
            webRequest.Headers.Add("Authorization", "Bearer XXXXXXXXXXXXXX");
            webRequest.ContentType = "application/json";
            webRequest.ContentLength = content.Length;
            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                streamWriter.Write(content);
                streamWriter.Flush();
                streamWriter.Close();
            }
            System.Net.WebResponse resp = webRequest.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string result = sr.ReadToEnd().Trim();
            sr.Close();
            resp.Close();
