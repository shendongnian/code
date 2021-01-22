	public class OpenSrs {
		private const string URL_BASE 		= "https://horizon.opensrs.net:55443";
		private const string RSP_USERNAME 	= "username";
		private const string PRIVATE_KEY 	= "PrivateKey";
		public string SendWebRequest(string postData)
		{
                WebRequest request = WebRequest.Create(URL_BASE);
                request.Method = "POST";
                request.ContentType = "text/xml";
                request.Headers.Add("X-Username", RSP_USERNAME);
                request.Headers.Add("X-Signature", Utility.md5Hash(
                            Utility.md5Hash(postData + PRIVATE_KEY) + PRIVATE_KEY));
                byte[] dataArray = Encoding.ASCII.GetBytes(postData);
                request.ContentLength = dataArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(dataArray, 0, dataArray.Length);
                dataStream.Close();
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string strResponse = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                return strResponse;			
		}
	}
