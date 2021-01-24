	string data = "{}";
	WebRequest myReq = WebRequest.Create(url);
	 //set webreuqest properties e.g
		//myReq.Method = "POST";
		//myReq.ContentLength =  lenght;
     UTF8Encoding enc = new UTF8Encoding();
     using (Stream ds = myReq.GetRequestStream())
     {
     ds.Write(enc.GetBytes(data), 0, data.Length);
     }
	 using (WebResponse wr = myReq.GetResponse())
     {
     Stream receiveStream = wr.GetResponseStream();
     using (StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8))
	{
		
		string content = reader.ReadToEnd();
		
	}
	}
