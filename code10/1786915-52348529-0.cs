    //entity
    public class Person
    {
    	public string FirstName {get; set;}
    	public string LastName {get; set;}
    }
    
    //base ViewModel
    public class PersonModel
    {
    	public string FirstName { get; set; }
        public string LastName { get; set; }
        // Standard format is Last, First
        public virtual string FullName => $"{LastName}, {FirstName}";
    }
    
    //customer specific ViewModel
    public class CustomerSpecificModel : PersonModel
    {
        // Standard format is Last, First
        public virtual string FullName => $"{FirstName} {LastName}";
    }
    
    
    //Mapping
    public class Mapping
    {
    	public void DoSomeWork()
    	{
    		var db = new People();
    		var defaultPerson = db.People.Select(p => new PersonModel
    		{
    			FirstName = p.FirstName,
    			LastName = p.LastName
    		};
    		
    		var customerSpecificModel = db.People.Select(p => new CustomerSpecificModel
    		{
    			FirstName = p.FirstName,
    			LastName = p.LastName
    		}
    		
    		Console.WriteLine(defaultPerson.First().FullName); //would return LastName, FirstName
    		Console.WriteLine(customerSpecificModel.First().FullName); //would return FirstName LastName
    	}	
    }
