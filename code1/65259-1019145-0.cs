		protected static string DoRequest()
		{
			string XML = "<?xml version=\"1.0\"?>"
				+"<methodCall>"
				+"<methodName>send</methodName>"
				+"    <params>"
				+"        <param>"
				+ "            <value><string>MY KEY</string></value>"
				+"        </param>"
				+"        <param>"
				+ "            <value><string>service@example.com</string></value>"
				+"       </param>"
				+"       <param>"
				+ "           <value><string>555555555</string></value>"
				+"       </param>"
				+"       <param>"
				+"          <value><string>Test Message</string></value>"
				+"      </param>"
				+"  </params>"
				+"</methodCall>";
			return SendText("http://api.pennysms.com/xmlrpc", XML);
		}
		public static string SendText(string _URL, string _parameters)
		{
			WebRequest request = WebRequest.Create(_URL);
			request.Method = "POST";
			string postData = _parameters;
			byte[] byteArray = Encoding.UTF8.GetBytes(postData);
			request.ContentType = "text/xml";
			request.ContentLength = byteArray.Length;
			Stream dataStream = request.GetRequestStream();
			dataStream.Write(byteArray, 0, byteArray.Length);
			dataStream.Close();
			
			long responseLength = request.GetResponse().ContentLength;
			Stream responseStream = request.GetResponse().GetResponseStream();
			MemoryStream memStream = new MemoryStream((int)responseLength);
			byteArray = new byte[4096];
			int bytesRead = 0;
			bytesRead = responseStream.Read(byteArray, 0, 4096);				
			while(bytesRead > 0)
			{
				memStream.Write(byteArray, 0, bytesRead);
				bytesRead = responseStream.Read(byteArray, 0, 4096);				
			}			
			return Encoding.UTF8.GetString(memStream.ToArray());
		}
