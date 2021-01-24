    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    public class Issue
    {
        public int? id { get; set; }
        public int project_id { get; set; }
        public string project_name { get; set; }
    	
    	public override string ToString()
    	{
    		return "Id: " + id + " project Id: " + project_id + " project name : " + project_name;
    	}
    }
    
    					
    public class Program
    {
    	public static void Main()
    	{
    		var text = "{ \"issue\" :  { \"id\": 1, \"project\": { \"id\": 2, \"name\":\"name of project\" }}}";
    		
    		var jObject = JsonConvert.DeserializeObject<JObject>(text);
    		
    		var issue = new Issue() {id = (int?)jObject["issue"]["id"], project_id = (int)jObject["issue"]["project"]["id"], project_name = (string)jObject["issue"]["project"]["name"]};
    		Console.WriteLine(issue);
    	}
    }
