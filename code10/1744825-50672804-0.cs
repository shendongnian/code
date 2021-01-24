    static void Main(string[] args)
    {
    	dynamic Json = new JObject() as dynamic;
    	Json = SaveValue<bool>(Json, "Bhop.Enabled", true);
    
    	Console.ReadLine();
    }
    
    static dynamic SaveValue<T>(dynamic jsonArray, string Object, T Value)
    {
    	jsonArray = new JObject();
    	jsonArray.Add(Object,Value);
    	return jsonArray;
    }
