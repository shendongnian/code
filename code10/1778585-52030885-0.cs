    public class Fields
    {
        public string SerialNumber { get; set; }
        public string id { get; set; }
    }
    
    public class Value
    {
        public Fields fields { get; set; }
    }
    
    public class RootObject
    {
        public List<Value> value { get; set; }
    }
 
    var obj = JsonConvert.DeserializeObject<RootObject>(jsonData);
    foreach (var item in obj.value)
    {
    	//item.fields.id
    	//item.fields.SerialNumber
    }
