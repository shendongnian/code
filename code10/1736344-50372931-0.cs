    public class Issue
    {
    	[ChoJSONRecordField(JSONPath = "$..id")]
    	public int? id { get; set; }
    	[ChoJSONRecordField(JSONPath = "$..project.id")]
    	public int project_id { get; set; }
    	[ChoJSONRecordField(JSONPath = "$..project.name")]
    	public string project_name { get; set; }
    }
    static void Sample33()
    {
    	string json = @"{
    	   ""issue"" : 
    	   {
    		  ""id"": 1,
    		  ""project"":
    		  {
    			 ""id"":1,
    			 ""name"":""name of project""
    		  }
    	   }
    	}";
    	var issue = ChoJSONReader<Issue>.LoadText(json).First();
    }
