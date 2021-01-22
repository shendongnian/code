            string formUrl = "http://localhost/pixelpost/admin/index.php?x=login"; 
            string formParams = string.Format("user={0}&password={1}", "username", "password");
            string cookieHeader;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(formUrl);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            req.AllowAutoRedirect = false;
            byte[] bytes = Encoding.ASCII.GetBytes(formParams);
            req.ContentLength = bytes.Length;
            using (Stream os = req.GetRequestStream())
            {
                os.Write(bytes, 0, bytes.Length);
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            cookieHeader = resp.Headers["Set-Cookie"];
            string pageSource;
            using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
            {
                pageSource = sr.ReadToEnd();
            }
            string getUrl = "http://localhost/pixelpost/admin/index.php";
            HttpWebRequest getRequest = (HttpWebRequest)HttpWebRequest.Create(getUrl);
            getRequest.Headers.Add("Cookie", cookieHeader);
            HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse();
            using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
            {
                pageSource = sr.ReadToEnd();
            }
            long length = 0;
            string boundary = "----------------------------" +
            DateTime.Now.Ticks.ToString("x");
            HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create("http://localhost/pixelpost/admin/index.php?x=save");
            httpWebRequest2.ContentType = "multipart/form-data; boundary=" + boundary;
            httpWebRequest2.Method = "POST";
            httpWebRequest2.AllowAutoRedirect = false;
            httpWebRequest2.KeepAlive = false;
            httpWebRequest2.Credentials = System.Net.CredentialCache.DefaultCredentials;
            httpWebRequest2.Headers.Add("Cookie", cookieHeader);
            Stream memStream = new System.IO.MemoryStream();
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary);
            string headerTemplate = "\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: image/jpeg\r\n\r\n";
            string header = string.Format(headerTemplate, "userfile", "Sunset.jpg");
            
            byte[] headerbytes = System.Text.Encoding.ASCII.GetBytes(header);
            memStream.Write(headerbytes, 0, headerbytes.Length);
            Image img = null;
            img = Image.FromFile("C:/Documents and Settings/Dorin Cucicov/My Documents/My Pictures/Sunset.jpg", true);
            img.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            
            memStream.Write(boundarybytes, 0, boundarybytes.Length);
            string formdataTemplate = "\r\nContent-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}";
            string formitem = string.Format(formdataTemplate, "headline", "Sunset");
            byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
            memStream.Write(formitembytes, 0, formitembytes.Length);
            memStream.Write(boundarybytes, 0, boundarybytes.Length);
            httpWebRequest2.ContentLength = memStream.Length;
            Stream requestStream = httpWebRequest2.GetRequestStream();
            memStream.Position = 0;
            byte[] tempBuffer = new byte[memStream.Length];
            memStream.Read(tempBuffer, 0, tempBuffer.Length);
            memStream.Close();
            requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            requestStream.Close();
            WebResponse webResponse2 = httpWebRequest2.GetResponse();
            Stream stream2 = webResponse2.GetResponseStream();
            StreamReader reader2 = new StreamReader(stream2);
            Console.WriteLine(reader2.ReadToEnd());
            webResponse2.Close();
            httpWebRequest2 = null;
            webResponse2 = null;
