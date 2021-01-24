    [HttpPost]
    public void Post()
    {
        using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
    	{
    		 var content = reader.ReadToEnd();
    		 dynamic data = JObject.Parse(content);
    		 Console.WriteLine(data.id);
    		 Console.WriteLine(data.date);
    	}
    }
