    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    	public override string ToString() { return FirstName + " " + LastName; }
    }
    //Main
	Mapper.Initialize( cfg => {} );
	dynamic source = new ExpandoObject();
	source.FirstName = "Hello";
	source.LastName = "World";
	var person = Mapper.Map<Person>(source);
		
	Console.WriteLine("GetType()= '{0}' ToString()= '{1}'", person.GetType().Name, person);
