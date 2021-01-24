    class Person 
    {
    
    public string Name  { get; set; }
    public static implicit operator string(Person person)
    {
    	return person.Name;
    }
    
    public static implicit operator Person(string name)
    {
    	return new Person(){Name=name};
    }
    }
