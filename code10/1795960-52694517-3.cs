    void Main()
    {
        var sp = new SpecialPlan();
        sp.Contact = new SpecialContact(); // new Contact(); won't compile
    	sp.Dump();
    }
    
    abstract class Contact
    {
    }
    
    class SpecialContact : Contact
    {
    }
    
    abstract class Plan<T> where T: Contact
    {
        public T Contact { get; set; }
    }
    
    class SpecialPlan : Plan<SpecialContact>
    {
    }
