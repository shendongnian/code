    public class Worker
    {
    	public string associateOID { get; set; }
    	// Any other attributes that you want to use as .NET types go here
        // all attributes that don't have a property will be put into this dictionary
        // either as primitive types, or as objects of type Newtonsoft.Json.Linq.JObject
        // supports nested objects of any Json structure, and will serialize correctly.
    	[JsonExtensionData]
    	public Dictionary<string,object> ExtraAttributes {get;set;}
    }
