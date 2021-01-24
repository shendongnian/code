    public class Person
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
    }
	
	public class RootObject
    {
        public Dictionary<string, Person> Result { get; set; }
    }
