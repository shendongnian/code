            String fullUrl = "http://...";
            String jsonStringContent = "{...}";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(fullUrl);
            req.Method = "POST";
            req.ContentType = "application/json";
            // content
            byte[] bytes = Encoding.UTF8.GetBytes(jsonStringContent);
            req.ContentLength = bytes.Length;
            Stream dataStream = req.GetRequestStream();
            dataStream.Write(bytes, 0, bytes.Length);
            dataStream.Close();
            //Response
            HttpWebResponse webresponse = (HttpWebResponse)req.GetResponse();
            reader = new StreamReader(webresponse.GetResponseStream());
            String responseString = reader.ReadToEnd();
            reader.Close();
