            // initiate xml 
            XmlDocument xml = new XmlDocument();
            xml.Load(xmlFile);
            byte[] bytes = Encoding.ASCII.GetBytes(xml.InnerXml);
            
            // setup request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            NetworkCredential cred = new NetworkCredential(uname, cipher);
            CredentialCache cache = new CredentialCache { { url, "Basic", cred } };
            request.PreAuthenticate = true;
            request.Credentials = cache;
            request.Method = "POST";
            request.ContentType = "application/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            // stream
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            // response        
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(responseStream, Encoding.Default);
            var xmlResponse = readStream.ReadToEnd();
