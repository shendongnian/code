    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
    }
    public class Test
    {
        [JsonConverter(typeof(StringObjectPropertyConverter<Person>))]
        public Person Person { get; set; }
    }
	
    var testObj = new Test()
    {
        Person = new Person() { Name = "John", Gender = "Male" }
    };
    var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(testObj);
	
