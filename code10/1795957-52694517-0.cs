    void Main()
    {
    	var sp = new SpecialPlan();
    	sp.Contact = new SpecialContact(); // new Contact(); won't compile
    }
    
    class Contact
    {
    }
    
    class SpecialContact : Contact
    {
    }
    
    class Plan<T>
    {
    	public T Contact { get; set; }
    }
    
    class SpecialPlan : Plan<SpecialContact>
    {
    }
