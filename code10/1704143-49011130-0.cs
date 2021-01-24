    private static HttpWebResponse MakeRequest(string url, string postArgument)
        {
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    
            request.Method = "POST";
           
            request.ContentType = "multipart/form-data;";
            Stream stream = request.GetRequestStream();
            string result = string.Format("arg1={0}", postArgument);
            byte[] value = Encoding.UTF8.GetBytes(result);
            stream.Write(value, 0, value.Length);
            stream.Close();
    
            return (HttpWebResponse)request.GetResponse();
        }
