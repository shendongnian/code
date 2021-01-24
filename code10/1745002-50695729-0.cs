		try{
		string contend = "";
                using (var streamReader = new StreamReader(new FileInfo(@"C:\Users\absmbez\Desktop\temp\upload.xml").OpenRead()))
                {
                    contend = streamReader.ReadToEnd();
                }
                HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
                webrequest.Method = "PUT";
                webrequest.ContentType = "application/xml";
                Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                byte[] requestData = enc.GetBytes(contend);
                webrequest.ContentLength = requestData.Length;
                using (var stream = webrequest.GetRequestStream())
                {
                    stream.Write(requestData, 0, requestData.Length);
                }
                HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
                StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
                string result = string.Empty;
                result = responseStream.ReadToEnd();
                webresponse.Close();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
