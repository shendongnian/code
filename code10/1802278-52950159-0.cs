    void Main()
    {
    	JObject jObject = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(path));
    	ReplaceCategoryValue(jObject, "Identity", "woop woop");
    	Console.WriteLine(jObject.ToString());
    }
    
    void ReplaceCategoryValue(JObject jObject, string categoryName, string newValue)
    {
    	JToken categories = jObject["Categories"];
    	JProperty targetProperty = categories.Children<JObject>().Properties().FirstOrDefault(x => x.Name == "Name" && x.Value.ToString() == categoryName);
    	if (targetProperty != null)
    	{
    		targetProperty.Value = newValue;
    	}
    }
