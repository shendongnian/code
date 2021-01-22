    [WebMethod]
    public static string JsonTester(string id)
    {
    	JavaScriptSerializer ser = new JavaScriptSerializer();
    
    	var jsonData = new MyData()
    	{
    		Name = "bob",
    		Age = 20,
    		Foods = new List<string>()
    	};
    
    	jsonData.Foods.Add("cheeseburger");
    	jsonData.Foods.Add("caviar");
    
    	var result = ser.Serialize(jsonData);
    	return result;
    }
