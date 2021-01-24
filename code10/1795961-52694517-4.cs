    void Main()
    {
        var sp = new SpecialPlan();
        sp.Contact = new SpecialContact(); // new Contact(); won't compile
    }
    
    abstract class Contact
    {
    }
    
    class SpecialContact : Contact
    {
    }
    
    abstract class Plan<T> where T: Contact
    {
    	protected T contact;
        public virtual T Contact { get { return contact; } set { contact = value; } }
    }
    
    class SpecialPlan : Plan<SpecialContact>
    {
    	public override SpecialContact Contact { get { return contact; } set { contact = value; } }
    }
