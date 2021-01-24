    var obj = JsonConvert.DeserializeObject<Rootobject>(input);
	var paramToAdd = JsonConvert.DeserializeObject<Parameter>(paramToAddJson);
	obj.parameters.Add(paramToAdd);
	
	var output = JsonConvert.SerializeObject(obj);
	output.Dump();
------
    public class Rootobject
    {
        public string id { get; set; }
        public string name { get; set; }
        public Category category { get; set; }
        public List<Parameter> parameters { get; set; }
    }
    
    public class Category
    {
        public string id { get; set; }
    }
    
    public class Parameter
    {
        public string id { get; set; }
        public string[] valuesIds { get; set; }
        public string[] values { get; set; }
        public object rangeValue { get; set; }
    }
