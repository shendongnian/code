    void Main()
    {
    	string a = null;
    	string b = null;
    	var peeps = new List<Person> { 
    		new Person { 
    			FirstName = "John",
    			LastName = "Connor"
    		},
    		new Person { 
    			FirstName = "Sarah",
    			LastName = "Connor",
    		},
    		new Person { 
    			FirstName = "Cletus",
    			LastName = "Handy"
    		}
    	};
    	
    	var somePeeps = from p in peeps
    		where (a == null || a.ToLower() == p.FirstName.ToLower()) 
    			&& (b == null || b.ToLower() == p.LastName.ToLower())
    		select p;
    	
    	somePeeps.Dump();
    		
    }
    
    public class Person
    {
    	public string FirstName { get; set;}
    	public string LastName { get; set;}
    }
