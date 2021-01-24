    void Main()
    {
	     var jsonString = @"{""Items"": {
					         ""Ids"": [
						         ""sometext"",
						         ""sometext""
						       ]
					        }}";
						
	    var items = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(jsonString);
    }
    public class RootObject {
	    public Items Items {get;set;}
    }
    public class Items {
	    public List<string> Ids {get;set;}
    }
