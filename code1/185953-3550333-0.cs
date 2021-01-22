	public interface IPerson
	{
		string FirstName { get; }
		string LastName { get; }
	}
    public class Person:IPerson
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
    public class SomeClass
    {
    public SomeClass(Person manager)
    {
        if (manager == null)
            throw new ArgumentNullException("manager");
        _manager = manager;
    }
    private readonly Person _manager;
    public IPerson Manager
    {
        get { return _manager; } //How do I make it readonly period!
    }
    }
