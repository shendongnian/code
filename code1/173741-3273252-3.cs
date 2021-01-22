            HttpWebRequest request = WebRequest.Create("http://google.com") as HttpWebRequest;
            //request.Accept = "application/xrds+xml";  
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            WebHeaderCollection header = response.Headers;
            var encoding = Encoding.GetEncoding(response.CharacterSet);
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                string responseText = reader.ReadToEnd();
            }
