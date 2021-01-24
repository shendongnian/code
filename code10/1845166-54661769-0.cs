    public class RootObject
    {
    	[JsonProperty(PropertyName = "results")]
        public ResultsObject results { get; set; }
    }
    public class RecordObject
    {
    	[JsonExtensionData]
    	public IDictionary<string,JToken> Data{get;set;}
    	
    	public IEnumerable<Record> RecordCollection => Data.Values.Select(jObject=> 
                          new Record
                          { 
                              Name=(string)jObject["name"],
                              Description=(string)jObject["description"]
                          });
    }
    
    
    public class ResultsObject
    {
        public RecordObject records { get; set; }
    }
