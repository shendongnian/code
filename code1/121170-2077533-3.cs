    HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create("http://localhost:2616/Default.aspx/JsonTester");
    request.ContentType = "application/json; charset=utf-8";
    request.Accept = "application/json, text/javascript, */*";
    request.Method = "POST";
    using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
    {
    	writer.Write("{id : 'test'}");
    }
    
    WebResponse response = request.GetResponse();
    Stream stream = response.GetResponseStream();
    string json = "";
    
    using (StreamReader reader = new StreamReader(stream))
    {	
    	while (!reader.EndOfStream)
    	{
    		json += reader.ReadLine();
    	}
    }
    
    // 3.5+ adds 'D' to the result, e.g.
    // {"d":"{\"Name\":\"bob\",\"Age\":20,\"Foods\":[\"cheeseburger\",\"caviar\"]}"}
    // So it thinks it's a dictionary with one key/value
    JavaScriptSerializer serializer = new JavaScriptSerializer();
    Dictionary<string, object> x = (Dictionary<string, object>)serializer.DeserializeObject(json);
    MyData data = serializer.Deserialize<MyData>(x["d"].ToString());
