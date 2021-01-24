    static void Main()
    {
    	var operation = new Operation<Dog>("Jack");
    	Console.WriteLine(operation.Animal.Name);
    	Console.ReadLine();
    }
    
    public interface IAnimal
    {
    	string Name { get; }
    }
    
    public class Dog : IAnimal
    {
    	public string Name { get; private set; }
    
    	public Dog()
    	{
    	}
    
    	public Dog(string name)
    	{
    		Name = name;
    	}
    }
    
    public class Operation<T> where T : IAnimal, new()
    {
    	public T Animal { get; private set; }
    
    	public Operation()
    	{
    		Animal = new T();
    	}
    
    	public Operation(params object[] args)
    	{
    		Animal = (T)Activator.CreateInstance(typeof(T), args);
    	}
    }
