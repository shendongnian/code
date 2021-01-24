    public class PetObject
    {
        public string name { get; set; }
        public string age { get; set; }
    }
    
    public class Foo
    {
        public string foo { get; set; }
    	public Pets pets {get;set;}
        
    }
    
    public class Pets
    {
    	public PetObject dog { get; set; }
    	public PetObject cat { get; set;}
    }
    public class Program
    {
	    public static void Main()
	    {
		    var json = "{\"foo\": \"bar\",\"pets\": {\"dog\": {\"name\": \"spot\",\"age\": \"3\"},\"cat\": {\"name\": \"wendy\",\"age\": \"2\"}}}";	
		
		    var content = JsonConvert.DeserializeObject<Foo>(json);
		
		    Console.WriteLine(content.pets.dog.name);	
			
	    }
    }
