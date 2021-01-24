    void Main()
    {
    	Foo<Animal> foo = new Foo<Animal>();
    	Animal animal = new Animal();
    	Console.Write(foo.Get(animal));
    }
    
    public class Animal
    {
    }
    
    public class Foo<T> {
    
    	public string Get(T entity)
    	{
    		return entity.GetType().Name;
    	}
    }
