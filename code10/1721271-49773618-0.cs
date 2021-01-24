        public static void STOCKUPLOAD()
        {
            string data = "";
            data += "articles[0][article_id]" + "=" + "4654-AB-XG";
            data += "&";
            data += "articles[0][brand_id]" + "=" + "30";
            data += "&";
            data += "articles[0][quantity]" + "=" + "80";
            data += "&";
            data += "articles[0][prices][1]" + "=" + "5.30";
            data += "&";
            data += "articles[0][prices][3]" + "=" + "5.80";
            data += "&";
            data += "articles[0][prices][12]" + "=" + "5.99";
            data += "&";
            // ----------------------------------------------
            data += "articles[1][article_id]" + "=" + "AB8888-123";
            data += "&";
            data += "articles[1][brand_id]" + "=" + "80";
            data += "&";
            data += "articles[1][quantity]" + "=" + "35";
            data += "&";
            data += "articles[1][prices][1]" + "=" + "4.25";
            data += "&";
            data += "articles[1][prices][2]" + "=" + "6.30";
            data += "&";
            data += "articles[1][prices][8]" + "=" + "5";
            byte[] dataStream = Encoding.UTF8.GetBytes(data);
            WebRequest webRequest = WebRequest.Create(uri);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(auth_data));
            webRequest.ContentLength = dataStream.Length;
            Stream newStream = webRequest.GetRequestStream();
            
            // Send the data.
            newStream.Write(dataStream, 0, dataStream.Length);
            newStream.Close();
            WebResponse webResponse = webRequest.GetResponse();
            string raw_json;
            using (var sr = new StreamReader(webResponse.GetResponseStream()))
            {
                raw_json = sr.ReadToEnd();
                Rootobject ob = JsonConvert.DeserializeObject<Rootobject>(raw_json);
                if(ob.code == 1000)
                {
                    System.Diagnostics.Debug.Print(ob.code_desc);
                }
            }
        }
