    void Main()
    {
    	JObject jObject = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(path));
    	JObject newCategory = new JObject();
    	newCategory.Add("Name", "Identity");
    	newCategory.Add("Mandatory", "false");
    	newCategory.Add("NewProp", "Yes");
    	ReplaceCategoryValue(jObject, "Identity", newCategory);
    
    	Console.WriteLine(jObject.ToString());
    }
    
    void ReplaceCategoryValue(JObject jObject, string categoryName, JObject newCategory)
    {
        JToken categories = jObject["Categories"];
        JObject targetCategory = categories.Children<JObject>().FirstOrDefault(x => x.Property("Name").Value.ToString() == categoryName);
    	targetCategory.Replace(newCategory);
    }
