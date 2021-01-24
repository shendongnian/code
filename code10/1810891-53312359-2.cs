    interface IDog
    {
    	void Bark();
    }
    
    interface ICat
    {
    	void Meow();
    }
    class SomeDog : IDog
    {
    	public void Bark()
    	{
    		Console.WriteLine(@"bark bark");
    	}
    }
    
    class SomeCat : ICat
    {
    	public void Meow()
    	{
    		Console.WriteLine(@"meow meow");
    	}
    }
    
    class CatToDogAdapter : IDog
    {
    	private ICat cat;
    	public CatToDogAdapter(ICat cat)
    	{
    		this.cat = cat;
    	}
    
    	public void Bark()
    	{
    		cat.Meow();
    	}
    }
    
    new Dog().Bark(); // bark bark
    new CatToDogAdapter().Bark();// meow meow
