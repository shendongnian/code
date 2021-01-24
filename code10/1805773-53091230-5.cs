    internal static string PostWebRequest(string PostUrl, string ParamData, Encoding DataEncode)
        {
            string ret = string.Empty;
            try
            {
                byte[] byteArray = DataEncode.GetBytes(ParamData);
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(PostUrl));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";
                webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return ret;
        }
