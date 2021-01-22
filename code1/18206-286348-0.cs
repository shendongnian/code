    public interface IFieldSimpleItem { }
    
    public interface IFieldNormalItem : IFieldSimpleItem{ }
    
    public interface IFieldCreator<TField, TPerson> where TField : IFieldSimpleItem where TPerson : Person
    {
    	TField Create(TPerson person);
    }
    
    public class Person
    {
    }
    
    public class Bose : Person
    {
    }
    
    public class PersonFieldCreator : IFieldCreator<IFieldSimpleItem, Person> 
    {
    	public IFieldSimpleItem Create(Person person) { return null; }
    }
    
    public class BoseFieldCreator : IFieldCreator<IFieldNormalItem, Bose>
    {
    	public IFieldNormalItem Create(Bose person) { return null; }
    }
