    public class Response{
      public Response(
        string response = "{\"result\": {\"version\":1,\"Id\": 1, \"FirstName\": \"Bob\", \"LastName\": \"Jones\"},\"error\":null,\"id\":\"getperson\"}";
        JsonConvert.PopulateObject(response, this);
      ){}
      public Person result{get;set;}
    }
    public class Person{
      public Person(){}
      public int Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public int Version { get; set; }
    }
