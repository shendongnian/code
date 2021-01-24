    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    
    public class Program
    {
    	public class Stage
    	{
    		[JsonProperty("stageInfo1")]
    		public string StageInfo1;
    	}
    
    	public class JsonData
    	{
    		[JsonProperty("stages")]
    		public Dictionary<string, Stage> Stages;
    	}
    
    	public static void Main()
    	{
    		var json = @"{
        ""name"": ""Example"",
        ""description"": ""Example JSON"",
        ""properties"":  {
             ""foo"": ""bar"",
             ""foo1"": ""bar2"",
             ""foo3"": ""bar4"",
        },
        ""stages"":  {
             ""This is a stage"": {
                  ""stageInfo1"": ""blah"",
                  ""stageInfo2"": ""blah"",
                  ""integration"": {
                      ""x"": ""x"",
                      ""y"": ""y"",
                      ""z"": ""z""
                  }
             },
             ""Another Stage"": {
                  ""stageInfo1"": ""blah"",
                  ""stageInfo2"": ""blah"",
                  ""integration"": {
                      ""x"": ""x"",
                      ""y"": ""y"",
                      ""z"": ""z""
                  }
             }
        }
     }";
    		var data = JsonConvert.DeserializeObject<JsonData>(json);
    		Console.WriteLine(data.Stages.Keys.ToArray());
    	}
    }
