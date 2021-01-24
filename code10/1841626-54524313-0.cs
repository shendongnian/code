    public class MyData{
      public ConnectionClass Connection {get;set;}
    }
    
    public ConnectionClass{
      [JsonProperty("data")] // to keep code styling consistent
      public string Data {get;set;}
    }
