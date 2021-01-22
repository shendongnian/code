    interface IPet { }
    
    class Cat : IPet
    {
    	public void eat(CommonFood food) { }
    	public void eat(CatFood food) { }
    }
    
    class Dog : IPet
    {
    	public void eat(CommonFood food) { }
    	public void eat(DogFood food) { }
    }
    
    interface IFood { }
    
    abstract class CommonFood : IFood { }
    
    abstract class CatFood : IFood { }
    
    abstract class DogFood : IFood { }
    
    class Milk : CommonFood { }
    
    class Fish : CatFood { }
    
    class Meat : DogFood { }
    
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		Dog myDog = new Dog();
    		myDog.eat(new Milk()); // ok, milk is common
    		myDog.eat(new Fish()); // error
    	}
    }
