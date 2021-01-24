    public class TestDataObject
    {
    	public Dictionary<string, object[]> parameters { get; set; }
    }
    string json = "{\"parameters\":{\"fields\":[\"a\",\"b\",\"c\"]}}";
    var serializer = new JavaScriptSerializer();
    var a = serializer.Deserialize<TestDataObject>(json);
    a.parameters["fields"].GetType() == typeof(object[]); //equals True
