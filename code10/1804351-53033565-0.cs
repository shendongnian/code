    public class SomeClass
    {
        public string Foo { get; set; }
        public int? Bar { get; set; }
    }
    ...
    
    var deserialized = JsonConvert.DeserializeObject<SomeClass>(json);
    if (deserialized.Bar == null)
    {
        // Whatever you want to do if it wasn't set
    }
