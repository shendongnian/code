    public class RootResponseClass
    {
       public List<ResponseParametersClass> d { get; set; }
    }
    JsonString = "{"d":"[{\"sname\":\"S1\",\"region\":\"R1\",\"name\":\"Q1\"},{\"sname\":\"S2\",\"region\":\"R2\",\"name\":\"Q2\"}]"}";
    var foo = JsonConvert.DeserializeObject<RootResponseClass>(JsonString);
